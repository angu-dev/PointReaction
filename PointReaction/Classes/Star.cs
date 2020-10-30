using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointReaction.Classes
{
    public class Star : Position
    {
        private int MINIMAL_SPIKES_COUNT = 4;
        private int MAXIMAL_SPIKES_COUNT = 6;
        private int MINIMAL_OUTER_RADIUS = 2;
        private int MAXIMAL_OUTER_RADIUS = 3;
        private int MINIMAL_INNER_RADIUS = 2;
        private int MAXIMAL_INNER_RADIUS = 3;

        private int _Spikes = 0;
        private int _OuterRadius = 0;
        private int _InnerRadius = 0;

        public int Spikes
        {
            get => _Spikes;
            set => SetSpikes(value);
        }
        public int OuterRadius
        {
            get => _OuterRadius;
            set => SetOuterRadius(value);
        }
        public int InnerRadius
        {
            get => _InnerRadius;
            set => SetInnerRadius(value);
        }
        public Color Color { get; set; }
        public Scale ScaleStar { get; set; }
        public Scale ScaleAlpha { get; set; }

        public Star(int positionX, int positionY) 
            : base (positionX, positionY)
        {
            SetSpikes();
            SetOuterRadius();
            SetInnerRadius();
        }
        public Star(int positionX, int positionY, int spikesCount)
            : base (positionX, positionY)
        {
            SetSpikes(spikesCount);
        }
        public Star(int positionX, int positionY, int outerRadius, int innerRadius)
            : base (positionX, positionY)
        {
            SetOuterRadius(outerRadius);
            SetInnerRadius(innerRadius);
        }
        public Star(int positionX, int positionY, int spikesCount, int outerRadius, int innerRadius)
            : base (positionX, positionY)
        {
            SetSpikes(spikesCount);
            SetOuterRadius(outerRadius);
            SetInnerRadius(innerRadius);
        }

        private void SetPosition(int positionX, int positionY)
        {
            X = positionX;
            Y = positionY;
        }
        private void SetSpikes()
        {
            int randomSpikesCount = Generator.RandomNumber(MINIMAL_SPIKES_COUNT, MAXIMAL_SPIKES_COUNT);
            SetSpikes(randomSpikesCount);
        }
        private void SetSpikes(int spikes)
        {
            if (spikes >= MINIMAL_SPIKES_COUNT && spikes <= MAXIMAL_SPIKES_COUNT)
            {
                _Spikes = spikes;
            }
        }
        private void SetOuterRadius()
        {
            int randomOuterRadius = Generator.RandomNumber(MINIMAL_OUTER_RADIUS, MAXIMAL_OUTER_RADIUS);
            SetOuterRadius(randomOuterRadius);
        }
        private void SetOuterRadius(int outerRadius)
        {
            if (outerRadius >= MINIMAL_OUTER_RADIUS && outerRadius <= MAXIMAL_OUTER_RADIUS)
            {
                _OuterRadius = outerRadius;
            }
        }
        private void SetInnerRadius()
        {
            int randomInnerRadius = Generator.RandomNumber(MINIMAL_INNER_RADIUS, MAXIMAL_INNER_RADIUS);
            SetInnerRadius(randomInnerRadius);
        }
        private void SetInnerRadius(int innerRadius)
        {
            if (innerRadius >= MINIMAL_INNER_RADIUS && innerRadius <= MAXIMAL_INNER_RADIUS)
            {
                _InnerRadius = innerRadius;
            }
        }
    }
}