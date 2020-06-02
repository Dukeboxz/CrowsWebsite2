using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowsWebsite.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string  Email { get; set; }

        public string PhoneNumber { get; set; }
        public List<Game> ownedGames { get; set; }

        public List<Game> LikeToPlayGames { get; set; }
    }
}
