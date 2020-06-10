using DataService.DTOs.ContractDTO;
using DataService.DTOs.TransactionDTO;
using DataService.Models;
using DataService.Services.TransactionService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransactionController : ControllerBase
    {
        private readonly DisneyDB _dbContext;

        public TransactionController(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult List(TransactionList_Rq rq)
        {
            ListTransactionService contractService = new ListTransactionService(_dbContext);
            TransactionList_Rs rs = contractService.Execute(rq);

            return Ok(rs);
        }

        [HttpPost]
        public IActionResult Create(Transaction_Rq rq)
        {
            CreateTransactionService contractService = new CreateTransactionService(_dbContext);
            Transaction_Rs rs = contractService.Execute(rq);

            return Ok(rs.ResponseCode);
        }

        [HttpPost]
        public IActionResult Update(Transaction_Rq rq)
        {
            UpdateTransactionService contractService = new UpdateTransactionService(_dbContext);
            Transaction_Rs rs = contractService.Execute(rq);

            return Ok(rs.ResponseCode);
        }

        [HttpPut]
        public IActionResult Delete(int id)
        {
            DeleteTransactionService contractService = new DeleteTransactionService(_dbContext);
            Transaction_Rs rs = contractService.Execute(id);

            return Ok(rs.ResponseCode);
        }
    }
}
