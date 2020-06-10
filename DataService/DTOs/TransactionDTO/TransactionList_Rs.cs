using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DTOs.TransactionDTO
{
    public class TransactionList_Rs : IResponseModel
    {
        public List<TransactionDTO> Data { get; set; }
    }
}
