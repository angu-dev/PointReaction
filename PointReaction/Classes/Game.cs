﻿using System;
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
                stars.Add(new Star()
                {
                    PositionX = Generator.GetRandomNumber(0, maximalGameWidth),
                    PositionY = Generator.GetRandomNumber(0, maximalGameHeight),
                    Spikes = Generator.GetRandomNumber(3, 7),
                    OuterRadius = Generator.GetRandomNumber(2, 4),
                    InnerRadius = Generator.GetRandomNumber(3, 4),
                    ScaleOptions = new Scale()
                    {
                        Type = Generator.GetRandomNumber(0, 2),
                        Value = (double)Generator.GetRandomNumber(0, 2) / 10,
                        Distance = Generator.GetRandomNumber(2, 5),
                        Count = Generator.GetRandomNumber(0, 4)
                    },
                    ColorOptions = new Color()
                    {
                        Red = 255,
                        Blue = 255,
                        Green = 255,
                        AlphaPercent = Generator.GetRandomNumber(30, 90),
                        ColorSettings = new Scale()
                        {
                            Type = Generator.GetRandomNumber(0, 2),
                            Value = Generator.GetRandomNumber(1, 10)
                        }
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
        public Scale ScaleOptions { get; set; }
        public Color ColorOptions { get; set; }
        
    }

    public class Color
    {
        public int Red { get; set; }
        public int Blue { get; set; }
        public int Green { get; set; }
        public int AlphaPercent { get; set; }
        public Scale ColorSettings { get; set; }
    }

    public class Scale
    {
        public int Type { get; set; }
        public double Value { get; set; }
        public int? Distance { get; set; }
        public int? Count { get; set; }
    }
}