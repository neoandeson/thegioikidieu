using DataService.DTOs.TransactionDTO;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Services.TransactionService
{
    public class ListTransactionService : IBaseService<TransactionList_Rq, TransactionList_Rs>
    {
        private readonly DisneyDB _dbContext;

        public ListTransactionService(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        public TransactionList_Rs Execute(TransactionList_Rq rq)
        {
            TransactionList_Rs rs = new TransactionList_Rs();

            try
            {
                rs.Data = _dbContext.Transactions.Where(t => t.ContractId == rq.ContractId)
                    .Select(s => new TransactionDTO
                    {
                        Id = s.Id,
                        AmountValue = s.AmountValue,
                        ContactNumber = s.ContactNumber,
                        ContactWho = s.ContactWho,
                        Description = s.Description,
                        Status = s.Status,
                        Time = s.Time,
                        Type = s.Type
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
