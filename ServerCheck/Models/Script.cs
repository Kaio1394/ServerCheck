﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCheck.Models
{
    public class Script
    {
        public string? Code { get; set; }
        public int? TimeoutSeconds { get; set; } = 60;
    }
}
