using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowsWebsite.Models.ViewModels
{
    public class GameChooseViewModel
    {
        public Member member { get; set; }

        public List<Game> OwnedGameSelection { get; set; } = new List<Game>();

        public List<Game> LikeToPlaySelection { get; set; } = new List<Game>();
    }
}
