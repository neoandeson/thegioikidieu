using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DTOs.TransactionDTO
{
    public class Transaction_Rq : IRequestModel<Transaction_Rq, Transaction>
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Type { get; set; }
        public double AmountValue { get; set; }
        public string ContactWho { get; set; }
        public string ContactNumber { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }

        public Transaction MapToEntity()
        {
            Transaction originModel = null;
            if (this != null)
            {
                originModel = new Transaction();

                originModel.Id = this.Id;
                originModel.Time = this.Time;
                originModel.Type = this.Type;
                originModel.AmountValue = this.AmountValue;
                originModel.ContactWho = this.ContactWho;
                originModel.ContactNumber = this.ContactNumber;
                originModel.Status = this.Status;
                originModel.Description = this.Description;
            }
            return originModel;
        }
    }
}
