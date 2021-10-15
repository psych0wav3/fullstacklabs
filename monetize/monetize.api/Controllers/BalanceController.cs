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
        private ICreateBalanceService _CreateBalanceservice;
        private IListBalanceService _ListBalanceService;
        private IUpdateBalanceService _UpdateBalanceService;
        private IConvertBalanceService _ConvertBalanceService;

        public BalanceController(
            ICreateBalanceService convertBalance,
            IListBalanceService listBalance,
            IUpdateBalanceService updateBalanceService,
            IConvertBalanceService ConvertBalanceService
        )
        {
            _CreateBalanceservice = convertBalance;
            _ListBalanceService = listBalance;
            _UpdateBalanceService = updateBalanceService;
            _ConvertBalanceService = ConvertBalanceService;
        }
        [HttpPost]
         public IActionResult Post([FromBody] CreateBalanceDTO balance)
         {
            if(ModelState.IsValid)
            {
                _CreateBalanceservice.Execute(balance);
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
        public ActionResult PostConvert([FromBody] ConvertBalanceDTO balance)
        {
            if(ModelState.IsValid)
            {
                _ConvertBalanceService.Execute(balance);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}