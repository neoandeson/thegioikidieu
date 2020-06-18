using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace DataService.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(20)]
        public string Username { get; set; }
        [Required, JsonIgnore]
        public string PasswordHash { get; set; }
        [Required, MaxLength(10)]
        public string Role { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}
