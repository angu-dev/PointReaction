using Microsoft.Ajax.Utilities;
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
    public class Generator
    {
        private static Random Random_Number = new Random();

        public static int RandomNumber(int minimalValue, int maximalValue)
        {
            return Random_Number.Next(minimalValue, maximalValue + 1);
        }
        public static double RandomAlphaNumber(double minimalValue, double maximalValue)
        {
            return Random_Number.NextDouble() * (maximalValue - minimalValue) + minimalValue;
        }
    }
}