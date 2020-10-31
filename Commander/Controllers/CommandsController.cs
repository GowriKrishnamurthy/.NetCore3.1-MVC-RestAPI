using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]

    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _commanderRepo;

        public CommandsController(ICommanderRepo commanderRepo)
        {
            this._commanderRepo = commanderRepo;
        }
        // GET: api/commands        
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _commanderRepo.GetAllCommands();
            return Ok(commandItems);
        }

        // GET: api/commands/5
        [HttpGet("{id}")]
        public ActionResult GetCommandById(int id)
        {
            var commandItem = _commanderRepo.GetCommandById(id);
            return Ok(commandItem);
        }

        // POST api/commands/5
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/commands/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/commands/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
