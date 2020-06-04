using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using CrowsWebsite.Services;
using Microsoft.AspNetCore.Http;
using CrowsWebsite.Models.ViewModels;

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

        public IActionResult SaveMemberParams(Member newMember)
        {
            MemberServices memberService = new MemberServices();


            string returnValue = memberService.SaveMember(newMember);

            if (returnValue.Equals("success"))
            {

                HttpContext.Session.SetInt32("memberId", newMember.Id);
                return View("Index", newMember);
            }

            return Content(returnValue);
        }

        public IActionResult LoadGameSelectionpage()
        {
            int memberId = (int)HttpContext.Session.GetInt32("memberId");

            MemberServices ms = new MemberServices();

            Member member = ms.GetMemberById(memberId); 

            if(member is null)
            {
                throw new Exception("did not get member from database");
            }

            GameChooseViewModel vm = new GameChooseViewModel();
            vm.member = member;
            return View("GameSelectionPage", vm);
        }
    }
}
