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
        private int DEFAULT_RANKLIST_ITEMS_COUNT = 5;
        private int BACKGROUND_STARS_COUNT = 200;
        public static Classes.Background Background = null;
        public static Classes.Game Animation = null;

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public void GenerateBackground(int backgroundWidth, int backgroundHeight)
        {
            Background = new Classes.Background(backgroundWidth, backgroundHeight, BACKGROUND_STARS_COUNT);
        }

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public void GenerateAnimation(int animationWidth, int animationHeight)
        {
            Animation = new Classes.Game(animationWidth, animationHeight, false);
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

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public string GetLeaderboard()
        {
            List<LeaderboardUser> userList = Leaderboard.GetLeaderboardUsers(DEFAULT_RANKLIST_ITEMS_COUNT);
            return JsonConvert.SerializeObject(userList);
        }
    }
}
