using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(new { Id = 1, Name = "Kalem", Price = 20 });
        }

        //api/porduct/kalem/20
        [HttpGet("{name}")]
        public IActionResult GetProdcut(string name)
        {
            return Ok(name);
        }

        //api/porduct/kalem/20
        [HttpGet("{name}/{price}")]
        public IActionResult GetProdcut(string name, int price)
        {
            return Ok(name +" "+price.ToString());
        }

        [HttpPost]
        public IActionResult SavePorduct()
        {
            return Ok(new { Status = "Success" });
        }
        [HttpPut]
        public IActionResult UpdateProuct()
        {
            return Ok();
        }
    }
}
