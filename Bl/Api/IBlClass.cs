﻿using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlClass
    {
        List<BlEvent> GetClassEvents(int Id);
    }
}
