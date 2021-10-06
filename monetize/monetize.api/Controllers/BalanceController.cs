using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using monetize.domain.dtos;
using monetize.domain.entities;
using monetize.domain.services;

namespace monetize.api.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalanceController : ControllerBase
    {
        private ICreateBalanceService _convertBalanceservice;
        private IListBalanceService _ListBalanceService;
        private IUpdateBalanceService _UpdateBalanceService;

        public BalanceController(
            ICreateBalanceService convertBalance,
            IListBalanceService listBalance,
            IUpdateBalanceService updateBalanceService
        )
        {
            _convertBalanceservice = convertBalance;
            _ListBalanceService = listBalance;
            _UpdateBalanceService = updateBalanceService;
        }
        [HttpPost]
         public IActionResult Post([FromBody] CreateBalanceDTO balance)
         {
            if(ModelState.IsValid)
            {
                _convertBalanceservice.Execute(balance);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
         async public Task<ActionResult> Get()
         {
            if(ModelState.IsValid)
            {
                var response = await _ListBalanceService.Execute();
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] UpdateBalanceDTO balance)
        {
            if(ModelState.IsValid)
            {
                _UpdateBalanceService.Execute(balance);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("/convert")]
        public ActionResult PostConvert([FromBody] Balance balance)
        {
            if(ModelState.IsValid)
            {
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}