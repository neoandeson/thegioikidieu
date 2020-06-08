using DataService.DTOs.ContractDTO;
using DataService.Models;
using System;
using System.Threading.Tasks;
using static DataService.Utilities.SystemEnum;

namespace DataService.Services.ContractService
{
    public class CreateTransactionService : IAsyncBaseService<Contract_Rq, Contract_Rs>
    {
        private DisneyDB _dbContext;

        public CreateTransactionService(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contract_Rs> Execute(Contract_Rq rq)
        {
            Contract_Rs rs = new Contract_Rs();

            try
            {
                Contract contract = rq.MapToEntity();
                if(contract != null)
                {
                    await _dbContext.Contracts.AddAsync(contract);
                    await _dbContext.SaveChangesAsync();

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
