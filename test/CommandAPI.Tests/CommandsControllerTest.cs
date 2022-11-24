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
using CommandAPI.Dtos;

namespace CommandAPI.Tests    
{
    public class CommandsControllerTests : IDisposable
    {
        Mock<ICommandAPIRepo> mockRepo;
        CommandsProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        public CommandsControllerTests()
        {
            mockRepo = new Mock<ICommandAPIRepo>();
            realProfile = new CommandsProfile();
            configuration = new MapperConfiguration(cfg => 
                cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);

        }

        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        [Fact]
        public void GetCommmandItems_Returns200Ok_WhenDBIsEmpty()
        {
            //Arrange
            
            mockRepo.Setup(repo => 
                repo.GetAllCommands()).Returns(GetCommand(0));
            
            var controller = new CommandsController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetAllCommands();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

         [Fact]
        public void GetAllCommmands_ReturnsOneItem_WhenDBHasOneResource()
        {
            //Arrange
            
            mockRepo.Setup(repo => 
                repo.GetAllCommands()).Returns(GetCommand(1));
            
            var controller = new CommandsController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetAllCommands();

            //Assert
            //Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var commands = okResult.Value as List<CommandReadDto>;
            Assert.Single(commands);
            

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
