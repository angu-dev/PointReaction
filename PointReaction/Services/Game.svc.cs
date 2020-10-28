using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Newtonsoft.Json;
using PointReaction.Classes;

namespace PointReaction.Services
{
    /*  
            GET:
                [WebGet(ResponseFormat = WebMessageFormat.Json)]

            POST:
                [WebInvoke(Method = "POST",
                BodyStyle = WebMessageBodyStyle.WrappedRequest,
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        */

    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Game
    {
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public string GenerateBackgroundStars(int starsCount, int maximalGameWidth, int maximalGameHeight)
        {
            return JsonConvert.SerializeObject(Classes.Game.GenerateBackgroundStars(starsCount, maximalGameWidth, maximalGameHeight));
        }

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public string GenerateAnimationDots(int dotsCount, int maximalGameWidth, int maximalGameHeight)
        {
            return JsonConvert.SerializeObject(Classes.Game.GenerateAnimationDots(dotsCount, maximalGameWidth, maximalGameHeight));
        }
    }
}
