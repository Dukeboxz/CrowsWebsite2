using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowsWebsite.Models.ViewModels
{
    public class GamingSessionViewModel
    {

        public Member Member { get; set; }

        public List<GamingSession> GamingSessions { get; set; }
    }
}
