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
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContractController : ControllerBase
    {
        private readonly DisneyDB _dbContext;

        public ContractController(DisneyDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult List(ContractList_Rq rq)
        {
            ListContractService contractService = new ListContractService(_dbContext);
            ContractList_Rs rs = contractService.Execute(rq);

            return Ok(rs);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contract_Rq rq)
        {
            CreateContractService contractService = new CreateContractService(_dbContext);
            Contract_Rs rs = await contractService.Execute(rq);

            return Ok(rs.ResponseCode);
        }

        [HttpPost]
        public IActionResult Update(Contract_Rq rq)
        {
            UpdateContractService contractService = new UpdateContractService(_dbContext);
            Contract_Rs rs = contractService.Execute(rq);

            return Ok(rs.ResponseCode);
        }

        [HttpPut]
        public IActionResult Delete (int id)
        {
            DeleteContractService contractService = new DeleteContractService(_dbContext);
            Contract_Rs rs = contractService.Execute(id);

            return Ok(rs.ResponseCode);
        }
    }
}
