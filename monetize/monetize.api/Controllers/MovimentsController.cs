using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using monetize.domain.entities;
using monetize.domain.Repositories;

namespace monetize.api.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentsController : ControllerBase
    {
        IBaseRepository<Moviments> _repository;
        public MovimentsController(IBaseRepository<Moviments> baseRepository){
            _repository = baseRepository;
        }
        [HttpPost]
         public ActionResult Post([FromBody] Moviments moviment){
            if(ModelState.IsValid){
               return Ok(moviment);
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