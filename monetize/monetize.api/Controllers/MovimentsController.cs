using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using monetize.domain.services;

namespace monetize.api.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentsController : ControllerBase
    {
        private IListMovimentsService _ListMovimentsService;

        public MovimentsController(
            IListMovimentsService listMovimentsService
        )
        {
            _ListMovimentsService = listMovimentsService;
        }
     
        [HttpGet]
         async public Task<ActionResult> Get()
         {
            if(ModelState.IsValid)
            {
                var response = await _ListMovimentsService.Execute();
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}