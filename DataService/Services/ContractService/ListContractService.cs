using DataService.DTOs.ContractDTO;
using DataService.Models;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Services.ContractService
{
    public class ListContractService : IBaseService<ContractList_Rq, ContractList_Rs>
    {
        private readonly DisneyDB _dbContext;

        public ListContractService(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        public ContractList_Rs Execute(ContractList_Rq rq)
        {
            ContractList_Rs rs = new ContractList_Rs();

            try
            {
                rs.Data = _dbContext.Contracts
                    .Where(c => c.UserId == rq.UserId && c.Status == rq.Status && c.RecordStatus == SystemEnum.RecordStatus.Active)
                    .Select(s => new ContractDTO() {
                        Id = s.Id,
                        Revenue = s.Revenue,
                        PackageName = s.PackageName,
                        Note = s.Note,
                        BuyDate = s.BuyDate,
                        BuyFrom = s.BuyFrom,
                        BuyPrice = s.BuyPrice,
                        Fee = s.Fee,
                        RevenuePercent = s.RevenuePercent,
                        SellDate = s.SellDate,
                        SellPrice = s.SellPrice,
                        SellTo = s.SellTo,
                        WaitingDate = s.WaitingDate
                    })
                    .ToList();
                return rs;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
