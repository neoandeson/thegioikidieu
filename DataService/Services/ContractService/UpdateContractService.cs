using DataService.DTOs.ContractDTO;
using DataService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;
using static DataService.Utilities.SystemEnum;

namespace DataService.Services.ContractService
{
    public class UpdateTransactionService : IBaseService<Contract_Rq, Contract_Rs>
    {
        private DisneyDB _dbContext;

        public UpdateTransactionService(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        public Contract_Rs Execute(Contract_Rq rq)
        {
            Contract_Rs rs = new Contract_Rs();

            try
            {
                Contract contract = _dbContext.Contracts.Where(c => c.Id == rq.Id).FirstOrDefault();
                if(contract != null)
                {
                    contract.Revenue = rq.Revenue;
                    contract.PackageName = rq.PackageName;
                    contract.Note = rq.Note;
                    contract.BuyDate = rq.BuyDate;
                    contract.BuyFrom = rq.BuyFrom;
                    contract.BuyPrice = rq.BuyPrice;
                    contract.Fee = rq.Fee;
                    contract.RevenuePercent = rq.RevenuePercent;
                    contract.SellDate = rq.SellDate;
                    contract.SellPrice = rq.SellPrice;
                    contract.SellTo = rq.SellTo;
                    contract.WaitingDate = rq.WaitingDate;

                    _dbContext.Entry(contract).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    rs.ResponseCode = ResponseCode.Success;
                }

                return rs;
            }
            catch (Exception)
            {
                rs.ResponseCode = ResponseCode.InternalServerError;
                throw;
            }
        }
    }
}
