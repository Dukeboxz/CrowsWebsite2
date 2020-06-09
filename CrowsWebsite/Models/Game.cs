using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowsWebsite.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string ApiId { get; set; }

        public string name { get; set; }

        public int min_players { get; set; }

        public int max_players { get; set; }

        public int min_playtime { get; set; }
        public int max_playtime { get; set; }

        public string img_url { get; set; }
        public string  rules_url { get; set; }
        public ICollection<MemberOwnedGames> MemberOwnedGames { get; set; }

        public ICollection<MemberLikeToPlayGames> MemberLikeToPlayGames { get; set; }
    }
}
