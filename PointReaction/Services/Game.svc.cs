using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using PointReaction.Classes;

namespace PointReaction.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Game
    {
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public string GetLeaderboard()
        {
            List<LeaderboardUser> leaderboardList = Leaderboard.GetLeaderboardUsers();
            return JsonConvert.SerializeObject(leaderboardList);
        }
    }
}
