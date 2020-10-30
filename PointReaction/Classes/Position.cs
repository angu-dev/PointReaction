using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointReaction.Classes
{
    public class Position
    {
        private int _X = 0;
        private int _Y = 0;

        public int X {
            get => _X;
            set => SetX(value);
        }
        public int Y {
            get => _Y;
            set => SetY(value);
        }

        public Position(int x, int y)
        {
            SetX(x);
            SetY(y);
        }

        private void SetX(int x)
        {
            _X = x;
        }
        private void SetY(int y)
        {
            _Y = y;
        }
    }
}