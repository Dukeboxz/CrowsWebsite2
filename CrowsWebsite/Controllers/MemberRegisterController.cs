using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowsWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrowsWebsite.Controllers
{
    public class MemberRegisterController : Controller
    {
        public IActionResult Index()
        {
            Member newMember = new Member();
            newMember.FirstName = "Stephen";
            return View("Index", newMember);
        }
    }
}
