using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointReaction.Classes
{
    public class LeaderboardUser
    {
        public string Username { get; set; }
        public long Points { get; set; }
        public long Coins { get; set; }
        public string Role { get; set; }
        public TimeSpan? Playtime { get; set; }
    }
}