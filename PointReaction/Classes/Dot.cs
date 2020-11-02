using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointReaction.Classes
{
    public class Dot : Position
    {
        public int MINIMAL_RADIUS = 10;
        public int MAXIMAL_RADIUS = 80;

        private int _Radius = 0;

        public int Radius
        {
            get => _Radius;
            set => SetRadius(value);
        }
        public Color Color { get; set; }
        public Scale Scale { get; set; }

        public Dot(int positionX, int positionY)
            : base(positionX, positionY)
        {
            SetRadius();
        }
        public Dot(int positionX, int positionY, int radius)
            : base(positionX, positionY)
        {
            SetRadius(radius);
        }

        private void SetRadius()
        {
            int randomRadius = Generator.RandomNumber(MINIMAL_RADIUS, MAXIMAL_RADIUS);
            SetRadius(randomRadius);
        }
        private void SetRadius(int radius) {
            if (radius >= MINIMAL_RADIUS && radius <= MAXIMAL_RADIUS)
            {
                _Radius = radius;
            }
        }
    }
}