using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataService.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(10)]
        public string PackageName { get; set; }
        [Required]
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        [Required]
        public double Revenue { get; set; }
        [Required]
        public int RevenuePercent { get; set; }
        [Required]
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
        [Required]
        public int WaitingDate { get; set; }
        [Required, MaxLength(20)]
        public string BuyFrom { get; set; }
        [MaxLength(20)]
        public string SellTo { get; set; }
        public double Fee { get; set; }
        public int Status { get; set; }
        [MaxLength(100)]
        public string Note { get; set; }
        [Required]
        public int RecordStatus { get; set; }

        public List<Transaction> Transactions { get; set; }
        public int UserId { get; set; }
    }
}
