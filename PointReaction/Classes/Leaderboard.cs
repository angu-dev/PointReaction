using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointReaction.Classes
{
    public abstract class Leaderboard
    {
        public static List<LeaderboardUser> GetLeaderboardUsers(int getItems)
        {
            List<LeaderboardUser> userList = new List<LeaderboardUser>();
            return userList;
        }
    }
}