using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Commander.Profiles;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]

    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _commanderRepo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            this._commanderRepo = commanderRepo;
            this._mapper = mapper;
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
        public ActionResult <CommandReadDto> GetCommandById(int id)
        { 
            var commandItem = _commanderRepo.GetCommandById(id);
            if (commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            
            return NotFound();
        }

        // POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _commanderRepo.CreateCommand(commandModel);
            _commanderRepo.SaveChanges();
            return Ok(commandModel);
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
