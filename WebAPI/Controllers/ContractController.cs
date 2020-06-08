using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DTOs.ContractDTO;
using DataService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataService.Services.ContractService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly DisneyDB _dbContext;

        public ContractController(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Create(Contract_Rq rq)
        {
            CreateTransactionService contractService = new CreateTransactionService(_dbContext);
            Contract_Rs rs = await contractService.Execute(rq);

            return Ok(rs.ResponseCode);
        }
    }
}
