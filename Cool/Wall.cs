﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool.Models
{
    public class Wall : Drawer
    {
        public Wall()
        {
            color = ConsoleColor.White;
            sign = '#';
        }
    }
}