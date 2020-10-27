using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace PointReaction.Classes
{
    public abstract class Game
    {
        public static List<Star> GenerateBackgroundStars(int starsCount, int maximalGameWidth, int maximalGameHeight)
        {
            List<Star> stars = new List<Star>();

            for (int currentValue = 0; currentValue < starsCount; currentValue++)
            {
                int positionX = Generator.GetRandomNumber(0, maximalGameWidth);
                int positionY = Generator.GetRandomNumber(0, maximalGameHeight);
                int spikes = Generator.GetRandomNumber(3, 7);
                int outerRadius = Generator.GetRandomNumber(2, 4);
                int innerRadius = Generator.GetRandomNumber(3, 4);
                string color = "rgba(255,255,240," + Generator.GetRandomNumber(30, 90).ToString() + ")";
                int type = Generator.GetRandomNumber(0, 2);
                double value = (double)Generator.GetRandomNumber(0, 2) / 10;
                int distance = Generator.GetRandomNumber(2, 5);
                int count = Generator.GetRandomNumber(0, 4);

                stars.Add(new Star()
                {
                    PositionX = positionX,
                    PositionY = positionY,
                    Spikes = spikes,
                    OuterRadius = outerRadius,
                    InnerRadius = innerRadius,
                    Color = color,
                    ScaleOptions = new Star.Scale()
                    {
                        Type = type,
                        Value = value,
                        Distance = distance,
                        Count = count
                    }
                });
            }

            return stars;
        }
    }

    public class Star
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Spikes { get; set; }
        public int OuterRadius { get; set; }
        public int InnerRadius { get; set; }
        public string Color { get; set; }
        public Scale ScaleOptions { get; set; }

        public class Scale
        {
            public int Type { get; set; }
            public double Value { get; set; }
            public int Distance { get; set; }
            public int Count { get; set; }
        }
    }
}