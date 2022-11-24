using System;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using CommandAPI.Models;
using CommandAPI.Data;
using Xunit;
using CommandAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Profiles;

namespace CommandAPI.Tests    
{
    public class CommandsControllerTests
    {
        [Fact]
        public void GetCommmandItems_Returns200Ok_WhenDBIsEmpty()
        {
            //Arrange
            var mockRepo = new Mock<ICommandAPIRepo>();

            mockRepo.Setup(repo => 
                repo.GetAllCommands()).Returns(GetCommand(0));

            var realProfile = new CommandsProfile();
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(realProfile));
            IMapper mapper = new Mapper(configuration);
            
            var contoller = new CommandsController(mockRepo.Object, mapper);
        }

        private List<Command> GetCommand(int num)
        {
            var commands = new List<Command>();
            if (num > 0){
                commands.Add(new Command
                {
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migration add <Name of Migration>",
                    Platform = ".Net Core EF"
                });
            }
            return commands;
        }
    }
}
