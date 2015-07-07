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
    public class Int64 : Binary64
    {
        public Int64(uint param1 = 0, uint param2 = 0): base(param1, param2)
        {
            return;
        }

        public long toNumber()
        {
            return this.high * 4294967296 + low;
        }

        public static Int64 fromNumber(double param1) 
        {
            return new Int64(Convert.ToUInt32(param1), Convert.ToUInt32(Math.Floor(param1 / 4294967296)));
        }
    }

    public class UInt64 : Binary64
    {
        public UInt64(uint param1 = 0, uint param2 = 0)
            : base(param1, param2)
        {
            return;
        }

        public ulong toNumber()
        {
            return (ulong)(high * 4294967296 + low);
        }

        public static Int64 fromNumber(double param1)
        {
            return new Int64(Convert.ToUInt32(param1), Convert.ToUInt32(Math.Floor(param1 / 4294967296)));
        }
    }
}
