using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            this._context = context;
        }
        public void CreateCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            _context.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            _context.Remove(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public void PatchCommand(Command command)
        {
            _context.Commands.Update(command);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateCommand(Command command)
        {
            _context.Commands.Update(command);
        }
    }
}
