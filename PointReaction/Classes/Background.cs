using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointReaction.Classes
{
    public class Background
    {
        private int MINIMAL_STARS_COUNT = 0;
        private int MAXIMAL_STARS_COUNT = 500;
        private int MINIMAL_BACKGROUND_WIDTH = 0;
        private int MINIMAL_BACKGROUND_HEIGHT = 0;
        private double MINIMAL_STARS_ALPHA_VALUE = 0.3;
        private double MAXIMAL_STARS_ALPHA_VALUE = 0.9;

        private List<Star> _Stars = new List<Star>();
        private int _StarsCount = 0;
        private int _BackgroundWidth = 0;
        private int _BackgroundHeight = 0;

        public List<Star> Stars
        {
            get => _Stars;
            set => SetStars(value);
        }
        public int StarsCount
        {
            get => _StarsCount;
            set => SetStarsCount(value);
        }
        public int BackgroundWidth
        {
            get => _BackgroundWidth;
            set => SetBackgroundWidth(value);
        }
        public int BackgroundHeight
        {
            get => _BackgroundHeight;
            set => SetBackgroundHeight(value);
        }

        public Background(int backgroundWidth, int backgroundHeight)
        {
            SetBackgroundWidth(backgroundWidth);
            SetBackgroundHeight(backgroundHeight);
            SetStarsCount();
            GenerateStars();
        }
        public Background(int backgroundWidth, int backgroundHeight, int starsCount)
        {
            SetBackgroundWidth(backgroundWidth);
            SetBackgroundHeight(backgroundHeight);
            SetStarsCount(starsCount);
            GenerateStars();
        }

        private void SetStars(List<Star> stars)
        {
            if (stars != null)
            {
                _Stars = stars;
            }
        }
        private void SetStarsCount()
        {
            int randomStarsCount = Generator.RandomNumber(MINIMAL_STARS_COUNT, MAXIMAL_STARS_COUNT);
            SetStarsCount(randomStarsCount);
        }
        private void SetStarsCount(int starsCount)
        {
            if (starsCount >= MINIMAL_STARS_COUNT && starsCount <= MAXIMAL_STARS_COUNT)
            {
                _StarsCount = starsCount;
            }
        }
        private void SetBackgroundWidth(int backgroundWidth)
        {
            if (backgroundWidth >= MINIMAL_BACKGROUND_WIDTH)
            {
                _BackgroundWidth = backgroundWidth;
            }
        }
        private void SetBackgroundHeight(int backgroundHeight)
        {
            if (backgroundHeight >= MINIMAL_BACKGROUND_HEIGHT)
            {
                _BackgroundHeight = backgroundHeight;
            }
        }

        private void GenerateStars()
        {
            List<Star> stars = new List<Star>();

            for (int starCounter = 0; starCounter < _StarsCount; starCounter++)
            {
                int positionX = Generator.RandomNumber(MINIMAL_BACKGROUND_WIDTH, _BackgroundWidth);
                int positionY = Generator.RandomNumber(MINIMAL_BACKGROUND_HEIGHT, _BackgroundHeight);

                Star star = new Star(positionX, positionY);

                double randomAlpha = Generator.RandomAlphaNumber(MINIMAL_STARS_ALPHA_VALUE, MAXIMAL_STARS_ALPHA_VALUE);
                star.Color = new Color(255, 255, 255, randomAlpha);

                stars.Add(star);
            }

            _Stars = stars;
        }

        public List<Star> GetStars()
        {
            return _Stars;
        }
    }
}