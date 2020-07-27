using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowsWebsite.Models;
using CrowsWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrowsWebsite.Controllers
{
    public class AdminPageController : Controller
    {
        public IActionResult Index()
        {
            Member mamber = new Member();
            return View("index", mamber);
        }

        public IActionResult GetMembersForAdmin()
        {
            return Content("Not Done Yet");
        }

        public IActionResult GetGameNightsForAdmin()
        {
            GamingSessionService service = new GamingSessionService();
            List<GamingSession> gamingSession = service.GetAllGamingSessions();

            return PartialView("_AdminGameNights", gamingSession);
        }


    }
}
