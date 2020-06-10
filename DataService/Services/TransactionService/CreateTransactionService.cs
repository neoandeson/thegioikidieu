using DataService.DTOs.TransactionDTO;
using DataService.Models;
using System;
using System.Threading.Tasks;
using static DataService.Utilities.SystemEnum;

namespace DataService.Services.TransactionService
{
    public class CreateTransactionService : IBaseService<Transaction_Rq, Transaction_Rs>
    {
        private DisneyDB _dbContext;

        public CreateTransactionService(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        public Transaction_Rs Execute(Transaction_Rq rq)
        {
            Transaction_Rs rs = new Transaction_Rs();

            try
            {
                Transaction transaction = rq.MapToEntity();
                if(transaction != null)
                {
                    _dbContext.Transactions.Add(transaction);
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
