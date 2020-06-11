using DataService.Infrastructures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.Models
{
    public class User : IEntityBase
    {
        [Key]
        public int IntId { get; set; }
        public string Id { get; set; }
        [Required, MinLength(4), MaxLength(20)]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
    }
}
