using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Newtonsoft.Json;
using PointReaction.Classes;

/*  
    GET:
        [WebGet(ResponseFormat = WebMessageFormat.Json)]

    POST:
        [WebInvoke(Method = "POST",
        BodyStyle = WebMessageBodyStyle.WrappedRequest,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
*/

namespace PointReaction.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Home
    {
        public static Background Background = null;
        public static Game Animation = null;

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public bool GenerateBackground(int backgroundWidth, int backgroundHeight)
        {
            Background = new Background(backgroundWidth, backgroundHeight, 200);
            return true;
        }

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public bool GenerateAnimation(int animationWidth, int animationHeight)
        {
            Animation = new Game(animationWidth, animationHeight, false);
            return true;
        }

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public string GetAnimation()
        {
            List<Dot> animationDots = new List<Dot>();
            if (Animation != null)
            {
                animationDots = Animation.GetDots();
            }
            return JsonConvert.SerializeObject(animationDots);
        }

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public string GetBackgroundStars()
        {
            List<Star> backgroundStars = new List<Star>();
            if (Background != null)
            {
                backgroundStars = Background.GetStars();
            }
            return JsonConvert.SerializeObject(backgroundStars);
        }
    }
}
