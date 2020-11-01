using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Data
{
    public class CommanderRepo : ICommanderRepo
    {
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Boil an egg", CommandLine ="Boil water", Platform="Kettle & Pan"},
                new Command{Id=1, HowTo="Cut bread", CommandLine ="Get a knife", Platform="knife & chopping board"},
                new Command{Id=2, HowTo="Make cup of tea", CommandLine ="Place teabag in cup", Platform="Kettle & cup"}
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", CommandLine = "Boil water", Platform = "Kettle & Pan" };
        }

        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void PatchCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
