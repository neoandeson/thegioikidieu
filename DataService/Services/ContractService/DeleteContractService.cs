using DataService.DTOs.ContractDTO;
using DataService.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using static DataService.Utilities.SystemEnum;

namespace DataService.Services.ContractService
{
    public class DeleteContractService : IBaseService<int, Contract_Rs>
    {
        private DisneyDB _dbContext;

        public DeleteContractService(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        public Contract_Rs Execute(int id)
        {
            Contract_Rs rs = new Contract_Rs();

            try
            {
                Contract contract = _dbContext.Contracts.Where(c => c.Id == id).FirstOrDefault();
                if(contract != null)
                {
                    _dbContext.Remove(contract);
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
