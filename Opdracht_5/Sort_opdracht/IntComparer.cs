﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_opdracht
{
    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x < y) return -1;
            if (x > y) return 1;
            return 0;
        }
    }
}
