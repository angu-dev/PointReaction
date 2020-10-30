using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointReaction.Classes
{
    public class Color
    {
        private int MINIMAL_COLOR_VALUE = 0;
        private int MAXIMAL_COLOR_VALUE = 255;
        private double MINIMAL_ALPHA_VALUE = 0;
        private double MAXIMAL_ALPHA_VALUE = 1;

        private int _Red = 0;
        private int _Green = 0;
        private int _Blue = 0;
        private double _Alpha = 1;

        public int Red {
            get => _Red;
            set => SetRed(value);
        }
        public int Green
        {
            get => _Green;
            set => SetGreen(value);
        }
        public int Blue
        {
            get => _Blue;
            set => SetBlue(value);
        }
        public double Alpha
        {
            get => _Alpha;
            set => SetAlpha(value);
        }

        public Color() { }
        public Color(double alpha)
        {
            SetAlpha(alpha);
        }
        public Color(int red, int green, int blue)
        {
            SetColor(red, green, blue);
        }
        public Color(int red, int green, int blue, double alpha)
        {
            SetColor(red, green, blue, alpha);
        }

        private void SetColor(int red, int green, int blue)
        {
            SetRed(red);
            SetGreen(green);
            SetBlue(blue);
        }
        private void SetColor(int red, int green, int blue, double alpha)
        {
            SetRed(red);
            SetGreen(green);
            SetBlue(blue);
            SetAlpha(alpha);
        }

        private void SetRed(int red)
        {
            if (CheckColorValue(red))
            {
                _Red = red;
            }
        }
        private void SetGreen(int green)
        {
            if (CheckColorValue(green))
            {
                _Green = green;
            }
        }
        private void SetBlue(int blue)
        {
            if (CheckColorValue(blue))
            {
                _Blue = blue;
            }
        }
        private void SetAlpha(double alpha)
        {
            alpha = Math.Round(alpha, 2);
            if (alpha >= MINIMAL_ALPHA_VALUE && alpha <= MAXIMAL_ALPHA_VALUE)
            {
                _Alpha = alpha;
            }
        }

        private bool CheckColorValue(int value)
        {
            return value >= MINIMAL_COLOR_VALUE && MAXIMAL_COLOR_VALUE <= 255;
        }
    }
}