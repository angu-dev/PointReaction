using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointReaction.Classes
{
    public abstract class Leaderboard
    {
        public static List<LeaderboardUser> GetLeaderboardUsers()
        {
            //List<LeaderboardUser> userList = new List<LeaderboardUser>();
            //return userList;
            return SymulateUsers(null);
        }

        public static List<LeaderboardUser> GetLeaderboardUsers(int getItems)
        {
            //List<LeaderboardUser> userList = new List<LeaderboardUser>();
            //return userList;
            return SymulateUsers(getItems);
        }

        public static List<LeaderboardUser> GetLeaderboardUsers(int skipItems, int getItems)
        {
            List<LeaderboardUser> userList = new List<LeaderboardUser>();
            return userList;
        }

        private static List<LeaderboardUser> SymulateUsers(int? getItems)
        {
            List<LeaderboardUser> list = new List<LeaderboardUser>();

            int max = 50;
            if (getItems != null) max = (int)getItems;

            for (int i = 0; i < max; i++)
            {
                list.Add(new LeaderboardUser()
                {
                    Username = "WWWWWWWWWWWWWWWWWWWWWWWWW",
                    Points = 83724934534582342,
                    Coins = 987234533323423,
                    Playtime = new TimeSpan(3, 2, 21),
                    Role = "Spieler"
                });
            }

            return list;
        }
    }
}