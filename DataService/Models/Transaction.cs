using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public int Type { get; set; }
        public double AmountValue { get; set; }
        [Required, MaxLength(50)]
        public string ContactWho { get; set; }
        [Required, MaxLength(14)]
        public string ContactNumber { get; set; }
        public int Status { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int RecordStatus { get; set; }

        public Contract Contract { get; set; }
    }
}
