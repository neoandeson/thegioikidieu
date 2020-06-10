using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DTOs.ContractDTO
{
    public class ContractList_Rq
    {
        public int UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Status { get; set; }
    }
}
