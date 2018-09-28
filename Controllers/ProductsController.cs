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
        public IActionResult Get(int id)
        {
            ProductModel product = _db.Products.FirstOrDefault(p => p.Id == id);
            if(product == null)
                return BadRequest("Product not found");
            return Ok(product);
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
        public IActionResult Put(int id, [FromBody]ProductModel item)
        {
            if(!ModelState.IsValid) 
                return BadRequest("Model invalid");

            _db.Update(item);
            _db.SaveChanges();
            return Ok(true);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProductModel product = _db.Products.FirstOrDefault(p => p.Id == id);
            if(product == null)
                return BadRequest();
            _db.Products.Remove(product);
            _db.SaveChanges();
            return Ok(true);
        }
    }
}
