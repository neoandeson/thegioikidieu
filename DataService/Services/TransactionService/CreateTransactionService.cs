using DataService.DTOs.TransactionDTO;
using DataService.Models;
using System;
using System.Threading.Tasks;
using static DataService.Utilities.SystemEnum;

namespace DataService.Services.TransactionService
{
    public class CreateTransactionService : IAsyncBaseService<Transaction_Rq, Transaction_Rs>
    {
        private DisneyDB _dbContext;

        public CreateTransactionService(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Transaction_Rs> Execute(Transaction_Rq rq)
        {
            Transaction_Rs rs = new Transaction_Rs();

            try
            {
                Transaction transaction = rq.MapToEntity();
                if(transaction != null)
                {
                    await _dbContext.Transactions.AddAsync(transaction);
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
