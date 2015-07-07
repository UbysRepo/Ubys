﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IO
{
    /// <summary>
    /// Nouveau Type (apparaît en 2.27)
    /// </summary>
    public class Binary64
    {
        public uint low;
        public uint high;

        public Binary64(uint param1 = 0, uint param2 = 0)
        {
            this.low = param1;
            this.high = param2;
        }
    }
}
