﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Data.Entities
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Temperature { get; set; }
    }
}
