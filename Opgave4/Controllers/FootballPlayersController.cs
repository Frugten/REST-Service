using Microsoft.AspNetCore.Mvc;
using Opgave4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Opgave4.Controllers
{
    [Route("api/David/")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();
        // GET: api/<FootballPlayersController>
        [HttpGet]
        public IEnumerable<FootballPlayer.FootballPlayer> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<FootballPlayersController>/5
        [HttpGet("{id}")]
        public FootballPlayer.FootballPlayer Get(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<FootballPlayersController>
        [HttpPost]
        public FootballPlayer.FootballPlayer Post([FromBody] FootballPlayer.FootballPlayer value)
        {
            return _manager.Add(value);
        }

        // PUT api/<FootballPlayersController>/5
        [HttpPut("{id}")]
        public FootballPlayer.FootballPlayer Put(int id, [FromBody] FootballPlayer.FootballPlayer value)
        {
            return _manager.Update(id, value);
        }

        // DELETE api/<FootballPlayersController>/5
        [HttpDelete("{id}")]
        public FootballPlayer.FootballPlayer Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
