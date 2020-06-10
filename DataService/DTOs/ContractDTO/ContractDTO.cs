using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DTOs.ContractDTO
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public string PackageName { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public double Revenue { get; set; }
        public int RevenuePercent { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
        public int WaitingDate { get; set; }
        public string BuyFrom { get; set; }
        public string SellTo { get; set; }
        public double Fee { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
    }
}
