using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using CrowsWebsite.Services;

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

        public IActionResult SameMemberParams(Member newMember)
        {
            MemberServices memberService = new MemberServices();

            string returnValue = memberService.SaveMember(newMember);

            return Content(returnValue);
        }
    }
}
