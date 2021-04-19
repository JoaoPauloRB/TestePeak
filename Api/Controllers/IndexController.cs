using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("")]
    public class IndexController : ControllerBase
    {
        private List<KeyValuePair<int, string>> list { get; set; }            
        public IndexController() {
            list = new List<KeyValuePair<int, string>>();
            list.Add(new KeyValuePair<int, string>(1, "João"));
            list.Add(new KeyValuePair<int, string>(2, "Maria"));
            list.Add(new KeyValuePair<int, string>(3, "Ana"));
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var name = list.FirstOrDefault(x => x.Key == id).Value;
            if(name == null) return NotFound(new { message= "Registro não encontrado" });

            return Ok(new {name});
        }

        [HttpPost]
        public IActionResult Post([FromBody]CalcValues values)
        {
            var total = values.installments * values.amount;
            return Ok(new { total = total * 1.05, values.installments, values.amount});
        }
    }

    public class CalcValues {
        public int installments { get; set; }
        public float amount { get; set; }
    }
}
