using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointReaction.Classes
{
    public abstract class Calculate
    {
        public static double GetDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Sqrt(Math.Pow(y1 - y2, 2) + Math.Pow(x1 - x2, 2));
        }
    }
}