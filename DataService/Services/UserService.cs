using DataService.Helpers;
using DataService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DataService.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly DisneyDB _dbContext;

        public UserService(IOptions<AppSettings> appSettings, DisneyDB dbContext)
        {
            _appSettings = appSettings.Value;
            _dbContext = dbContext;
        }

        public User Authenticate(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Username == username);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();

            //Remove return user's password
            user.PasswordHash = "";

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> userlist =_dbContext.Users.ToList();
            foreach (var user in userlist)
            {
                user.PasswordHash = string.Empty;
            }

            return userlist;
        }

        public User GetById(int id)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            user.PasswordHash = string.Empty;
            return user;
        }
    }
}
