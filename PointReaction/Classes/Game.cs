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
                int currentStarPositionX = Generator.GetRandomNumber(0, maximalGameWidth);
                int currentStarPositionY = Generator.GetRandomNumber(0, maximalGameHeight);
                int currentStarSpikes = Generator.GetRandomNumber(3, 7);
                int currentStarOuterRadius = Generator.GetRandomNumber(2, 4);
                int currentStarInnerRadius = Generator.GetRandomNumber(3, 4);
                int currentStarTransparencyInPercent = Generator.GetRandomNumber(10, 90);

                stars.Add(new Star()
                    {
                        PositionX = currentStarPositionX,
                        PositionY = currentStarPositionY,
                        Spikes = currentStarSpikes,
                        OuterRadius = currentStarOuterRadius,
                        InnerRadius = currentStarInnerRadius,
                        TransparencyInPercent = currentStarTransparencyInPercent
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
        public int TransparencyInPercent { get; set; }
    }
}