using CrowsWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowsWebsite.Services
{
    public class GamingSessionService
    {

        public List<GamingSession> GetAllGamingSessions()
        {
            List<GamingSession> gamingSessions;
            try
            {
                using (var db = new websiteContext())
                {
                    gamingSessions = db.GamingSessions.Where(x => x.DateOfSession > DateTime.Now).ToList();
                }

                return gamingSessions;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}
