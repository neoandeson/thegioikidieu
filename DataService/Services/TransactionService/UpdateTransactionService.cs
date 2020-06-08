using DataService.DTOs.TransactionDTO;
using DataService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;
using static DataService.Utilities.SystemEnum;

namespace DataService.Services.TransactionService
{
    public class UpdateTransactionService : IBaseService<Transaction_Rq, Transaction_Rs>
    {
        private DisneyDB _dbContext;

        public UpdateTransactionService(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        public Transaction_Rs Execute(Transaction_Rq rq)
        {
            Transaction_Rs rs = new Transaction_Rs();

            try
            {
                Transaction transaction = _dbContext.Transactions.Where(c => c.Id == rq.Id).FirstOrDefault();
                if(transaction != null)
                {
                    transaction.Id = rq.Id;
                    transaction.Time = rq.Time;
                    transaction.Type = rq.Type;
                    transaction.AmountValue = rq.AmountValue;
                    transaction.ContactWho = rq.ContactWho;
                    transaction.ContactNumber = rq.ContactNumber;
                    transaction.Status = rq.Status;
                    transaction.Description = rq.Description;

                    _dbContext.Entry(transaction).State = EntityState.Modified;
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
