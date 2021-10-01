using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestController.Controllers;
using RestController.Managers;
using RestController.Models;

namespace RestController.Controller
{
    [Route("api/[controller]")]
    // the controller is available on ..../api/books
    // [controller] means the name of the controller minus "Controller"
    [ApiController]
    public class ItemsController: ControllerBase
    {
        
            private readonly ItemsManager _manager = new ItemsManager();

            // GET: api/<BooksController>
            [HttpGet("{substring}")]
            public IEnumerable<Item> Get(string substring)
            {

                return _manager.GetAll(substring);
            }

            // GET api/<BooksController>/5
            /*[HttpGet("{id}")]
            public Item Get(int id)
            {
                return _manager.GetById(id);
            }*/

            // POST api/<BooksController>
            [HttpPost]
            public Item Post([FromBody] Item value)
            {
                return _manager.Add(value);
            }

            // PUT api/<BooksController>/5
            [HttpPut("{id}")]
            public Item Put(int id, [FromBody] Item value)
            {
                return _manager.Update(id, value);
            }

            // DELETE api/<BooksController>/5
            [HttpDelete("{id}")]
            public Item Delete(int id)
            {
                return _manager.Delete(id);
            }

            public ActionResult<IEnumerable<Item>> GetWithContains(string substring)
            {
                List<Item> result = _manager.GetAll(substring);
                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }

    }
}
