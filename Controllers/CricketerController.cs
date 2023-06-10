using CricketCrudApi.Data;
using CricketCrudApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CricketCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CricketerController : ControllerBase
    {
        private readonly CricketApiDbContext context;

        public CricketerController(CricketApiDbContext apiDbContext)
        {
            context = apiDbContext;
        }

        [HttpGet]
        public IActionResult GetCricketers()
        {
            var cricketer=context.CricketerDetails.ToList();
            if(cricketer.Count==0)
            {
                return NotFound("Cricketer Not Found.");
            }
            return Ok(cricketer);
        }

        [HttpGet("{id}")]
        public IActionResult GetCricketerById(int id)
        {
            var cricketer = context.CricketerDetails.Find(id);
            if(cricketer == null)
            {
                return NotFound("Cricketer With This Id Not available");
            }
            return Ok(cricketer);
        }


        [HttpPost]
        public IActionResult AddCricketers(Cricket cricketer)
        {
            context.CricketerDetails.Add(cricketer);
            context.SaveChanges();
            return Ok("Cricketer Added Successfully..");
        }

        [HttpPut]

        public IActionResult UpdateCricketer(Cricket cricketer) { 
        
            if(cricketer == null|| cricketer.cricketerId==0) {

                return BadRequest("Invalid");
            }
            var Cricketer = context.CricketerDetails.Find(cricketer.cricketerId);
            if(Cricketer == null)
            {
                return NotFound("Does not exist");
            }
            Cricketer.cricketerName = cricketer.cricketerName;
            Cricketer.cricketerRole = cricketer.cricketerRole;
            Cricketer.country = cricketer.country;
            context.SaveChanges();
            return Ok("Cricketer Updated Succesfully.");
        }

        [HttpDelete]
        public IActionResult DeleteCricketer(int Id)
        {
            var Cricketer = context.CricketerDetails.Find(Id);
            if (Cricketer == null)
            {
                return NotFound("Does not exist");
            }
            context.CricketerDetails.Remove(Cricketer);
            context.SaveChanges();
            return Ok("Cricketer Deleted Succesfully..");
        }

        [HttpGet("Search")]
        public IActionResult SearchCricketers([ModelBinder(typeof(CustomBinder))] string[] cricketers)
        {
            return Ok(cricketers);
        }
    }
}
