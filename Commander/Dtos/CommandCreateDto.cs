﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        public string HowTo { get; set; }
        public string CommandLine { get; set; }        
        public string Platform { get; set; }
    }
}
