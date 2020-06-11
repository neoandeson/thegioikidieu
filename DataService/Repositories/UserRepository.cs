using DataService.Infrastructures;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Repositories
{
    public interface IUserRepository : IEntityBaseRepository<User> {
        bool isEmailUniq(string email);
        bool IsUsernameUniq(string username);
    }

    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(DisneyDB context) : base(context) { }

        public bool isEmailUniq(string email)
        {
            var user = this.GetSingle(u => u.Email == email);
            return user == null;
        }

        public bool IsUsernameUniq(string username)
        {
            var user = this.GetSingle(u => u.Username == username);
            return user == null;
        }
    }
}
