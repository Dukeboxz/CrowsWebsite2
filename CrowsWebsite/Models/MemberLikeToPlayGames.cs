using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowsWebsite.Models
{
    public class MemberLikeToPlayGames
    {

        public int MemberId { get; set; }

        public Member Member { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
