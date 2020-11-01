using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Commander.Profiles;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name = "GetCommandById")]
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

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            //pass back the location the new resource has been created
            return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDto.Id }, commandReadDto);
            // return Ok(commandReadDto);
        }

        // PUT api/commands/5
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepository = _commanderRepo.GetCommandById(id);
            if (commandModelFromRepository != null)
            {
                _mapper.Map(commandUpdateDto, commandModelFromRepository);
                _commanderRepo.UpdateCommand(commandModelFromRepository);
                _commanderRepo.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/commands/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepository = _commanderRepo.GetCommandById(id);
            if (commandModelFromRepository != null)
            {
                _commanderRepo.DeleteCommand(commandModelFromRepository);
                _commanderRepo.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }

        // PATCH api/commands/5
        [HttpPatch("{id}")]
        public ActionResult ParticalCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandModelFromRepository = _commanderRepo.GetCommandById(id);
            if (commandModelFromRepository != null)
            {
                var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepository);
                patchDocument.ApplyTo(commandToPatch,ModelState);

                if(!TryValidateModel(commandToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                _mapper.Map(commandToPatch, commandModelFromRepository);
                _commanderRepo.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }
    }
}
