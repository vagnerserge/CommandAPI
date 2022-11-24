using System;
using Xunit;
using CommandAPI.Models;

namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;

        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "Some platform",
                CommandLine = "dotnet test"
            };

        }

        public void Dispose()
        {
            testCommand = null;
        }



        [Fact]
        public void CanChangeHowTo()
        {
            //Arrange
            var testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };

            //Act
            testCommand.HowTo = "Execute Unit Tests";

             //Assert
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }

        
        [Fact]
        public void CanChangePlatform()
        {
            //Arrange
            var testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };

            //Act
            testCommand.Platform = "Linux";

             //Assert
            Assert.Equal("Linux", testCommand.Platform);
        }

                [Fact]
        public void CanChangeCommandLine()
        {
            //Arrange
            var testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };

            //Act
            testCommand.CommandLine = "run";

             //Assert
            Assert.Equal("run", testCommand.CommandLine);
        }



    }
 }
