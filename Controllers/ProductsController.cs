using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        ApplicationContext _db;

        public ProductsController(ApplicationContext db)
        {
            _db = db;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return _db.Products.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ProductModel item)
        {
            if(!ModelState.IsValid)
                return BadRequest("Model invalid");

            _db.Products.Add(item);
            _db.SaveChanges();
            return Ok(true);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
