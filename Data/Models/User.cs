﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class User : IData
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
