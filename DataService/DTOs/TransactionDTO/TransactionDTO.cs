using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DTOs.TransactionDTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Type { get; set; }
        public double AmountValue { get; set; }
        public string ContactWho { get; set; }
        public string ContactNumber { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
    }
}
