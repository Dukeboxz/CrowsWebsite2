using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowsWebsite.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string  Email { get; set; }

        public string PhoneNumber { get; set; }
        public ICollection<MemberOwnedGames> MemberOwnedGames { get; set; }

        public ICollection<MemberLikeToPlayGames> MemberLikeToPlayGames { get; set; }


        public List<Game> OwnedGames { get; set; }

        public List<Game> LikeToPlayGames { get; set; }
    }
}
