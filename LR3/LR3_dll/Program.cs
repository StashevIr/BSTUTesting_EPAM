using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR3_dll
{
    public class Triangle
    {
        public static bool IsTriangle(double a, double b, double c)
        {
            return ((a + b > c) && (a + c > b) && (b + c > a) && a > 0 && b > 0 && c > 0);
        }
    }
}
