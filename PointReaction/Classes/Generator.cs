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
        public static Random RandomNumber = new Random();

        public static int GetRandomNumber(int minimalValue, int maximalValue)
        {
            return RandomNumber.Next(minimalValue, maximalValue);
        }
    }
}