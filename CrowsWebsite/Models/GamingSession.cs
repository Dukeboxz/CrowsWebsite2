using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowsWebsite.Models
{
    public class GamingSession
    {
        public int Id { get; set; }

        public DateTime DateOfSession { get; set; }

        public List<Member> Atendees { get; set; }
    }
}
