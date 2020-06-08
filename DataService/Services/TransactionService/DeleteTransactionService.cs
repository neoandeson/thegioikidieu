using DataService.DTOs.TransactionDTO;
using DataService.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using static DataService.Utilities.SystemEnum;

namespace DataService.Services.TransactionService
{
    public class DeleteTransactionService : IBaseService<int, Transaction_Rs>
    {
        private DisneyDB _dbContext;

        public DeleteTransactionService(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        public Transaction_Rs Execute(int id)
        {
            Transaction_Rs rs = new Transaction_Rs();

            try
            {
                Transaction transaction = _dbContext.Transactions.Where(c => c.Id == id).FirstOrDefault();
                if(transaction != null)
                {
                    _dbContext.Remove(transaction);

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
