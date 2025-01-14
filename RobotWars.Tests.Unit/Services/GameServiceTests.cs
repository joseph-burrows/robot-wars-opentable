﻿using Moq;
using NUnit.Framework;
using RobotWars.Models;
using RobotWars.Services;
using RobotWars.Services.Interfaces;
using System.Collections.Generic;

namespace RobotWars.Tests.Unit.Services
{
    public class GameServiceTests
    {
        private IGameService _gameService;

        private Mock<IGameBuilder> _mockGameBuilder = new Mock<IGameBuilder>();
        private Mock<IInputParser> _mockInputParser = new Mock<IInputParser>();
        private Mock<IGameEvaluator> _mockGameEvaluator = new Mock<IGameEvaluator>();
        private Mock<IGameOutput> _mockGameOutput = new Mock<IGameOutput>();

        [SetUp]
        public void SetUp()
        {
            _gameService = new GameService(
                _mockGameBuilder.Object,
                _mockInputParser.Object,
                _mockGameEvaluator.Object,
                _mockGameOutput.Object);
        }

        [Test]
        public void Play_WithValidInput_ShouldCallOutput()
        {
            // Arrange
            var game = new Game
            {
                Arena = new Arena { Height = 5, Width = 5 },
                Robots = new List<Robot>
                    {
                        new Robot
                        {
                            Position = new Coordinate { X = 2, Y = 2 },
                            Heading = Heading.N,
                            Commands = new List<Command>()
                        },
                        new Robot
                        {
                            Position = new Coordinate { X = 3, Y = 3 },
                            Heading = Heading.E,
                            Commands = new List<Command>()
                        },
                        new Robot
                        {
                            Position = new Coordinate { X = 4, Y = 4 },
                            Heading = Heading.S,
                            Commands = new List<Command>()
                        },
                        new Robot
                        {
                            Position = new Coordinate { X = 5, Y = 5 },
                            Heading = Heading.W,
                            Commands = new List<Command>()
                        }
                    }
            };

            _mockGameBuilder.Setup(x => x.Build(It.IsAny<List<string>>())).Returns(game);

            // Act
            _gameService.Play();

            // Assert
            _mockGameOutput.Verify(x => x.Output(It.Is<Game>(y => y == game)));
        }
    }
}
