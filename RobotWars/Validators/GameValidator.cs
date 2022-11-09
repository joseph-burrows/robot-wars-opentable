﻿using FluentValidation;
using RobotWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Validators
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {

            RuleFor(x => x.Arena).NotNull();
            RuleFor(x => x.Robots).NotNull();

            RuleFor(x => x).Must(BeInBounds);
        }

        private bool BeInBounds(Game game)
        {
            var robots = game.Robots;
            var width = game.Arena.Width;
            var height = game.Arena.Height;

            foreach(var robot in robots)
            {
                if (robot.Position.X < 0 || robot.Position.X > width) return false;
                if (robot.Position.Y < 0 || robot.Position.Y > height) return false;
            }

            return true;
        }

    }
}