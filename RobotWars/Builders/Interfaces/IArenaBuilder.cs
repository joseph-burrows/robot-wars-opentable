﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Services.Interfaces
{
    public interface IArenaBuilder
    {
        Arena Build(string input);
    }
}
