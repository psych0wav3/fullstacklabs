using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using monetize.domain.entities;
using monetize.domain.Repositories;

namespace monetize.api.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalanceController : ControllerBase
    {
        IBaseRepository<Balance> _repository;

        public BalanceController(IBaseRepository<Balance> repo){
            _repository = repo;
        }
        [HttpPost]
        async public Task<ActionResult> Post([FromBody] Balance balance){
            if(ModelState.IsValid){
                await _repository.Create(balance);
                await _repository.SaveChangesAsync();
                return Ok(await _repository.Read());
            }
            else{
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
         public ActionResult Get(){
            if(ModelState.IsValid){
            
                return Ok();
            }
            else{
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public ActionResult Put(){
            if(ModelState.IsValid){
            
                return Ok();
            }
            else{
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
         public ActionResult Delete(){
            if(ModelState.IsValid){
            
                return Ok();
            }
            else{
                return BadRequest(ModelState);
            }
        }
    }
}