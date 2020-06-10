using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DTOs.ContractDTO
{
    public class ContractList_Rs : IResponseModel
    {
        public List<ContractDTO> Data { get; set; }
    }
}
