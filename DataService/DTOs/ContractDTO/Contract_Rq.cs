using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DTOs.ContractDTO
{
    public class Contract_Rq : IRequestModel<Contract_Rq, Contract>
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

        public Contract MapToEntity()
        {
            Contract originModel = null;
            if (this != null)
            {
                originModel = new Contract();

                originModel.Id = this.Id;
                originModel.Revenue = this.Revenue;
                originModel.PackageName = this.PackageName;
                originModel.Note = this.Note;
                originModel.BuyDate = this.BuyDate;
                originModel.BuyFrom = this.BuyFrom;
                originModel.BuyPrice = this.BuyPrice;
                originModel.Fee = this.Fee;
                originModel.RevenuePercent = this.RevenuePercent;
                originModel.SellDate = this.SellDate;
                originModel.SellPrice = this.SellPrice;
                originModel.SellTo = this.SellTo;
                originModel.WaitingDate = this.WaitingDate;
            }
            return originModel;
        }
    }
}
