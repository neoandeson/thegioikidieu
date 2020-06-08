using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(20)]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
    }
}
