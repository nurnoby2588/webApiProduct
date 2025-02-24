using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApiProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public List<string> fruits = new List<string>()
        {
           "apple",
           "mango",
           "banna",
           "orange",
           "carrot",
           "tomato",

        };

        [HttpGet("GetAllFruits")]
        public List<string> GetAllFruits()
        {
            return fruits;
        }

        [HttpGet("fruit/{id}")]
        public string GetFruits(int id) { 
        return fruits.ElementAt(id);
        }
       
      
    }
}
