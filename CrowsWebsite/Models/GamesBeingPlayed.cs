using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowsWebsite.Models
{
    public class GamesBeingPlayed
    {
        public int Id { get; set;  }
        public Game Game { get; set; }

        public List<Member> Players { get; set; }

        public int SpacesAvailable { get; set; } 
    }
}
