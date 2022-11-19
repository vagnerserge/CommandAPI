using System.Collections.Generic;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{
                    Id=0, HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migration add <Name of Migaration>",
                    Platform = ".Net Core EF"},
                new Command{
                    Id=0, HowTo = "Run Migrations",
                    CommandLine = "dotnet ef database update>",
                    Platform = ".Net Core EF"},
                 new Command{
                    Id=0, HowTo = "List active migaration",
                    CommandLine = "dotnet ef database list>",
                    Platform = ".Net Core EF"},
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{
                Id=0, HowTo = "How to generate a migration",
                CommandLine = "dotnet ef migration add <Name of Migaration>",
                Platform = ".Net Core EF" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}