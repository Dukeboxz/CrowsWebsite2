using System;
using System.Collections.Generic;
using CrowsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using CrowsWebsite.Services;
using Microsoft.AspNetCore.Http;
using CrowsWebsite.Models.ViewModels;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Configuration;

namespace CrowsWebsite.Controllers
{
    public class MemberRegisterController : Controller
    {
        public IConfiguration Configuration { get; }

        public MemberRegisterController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {

            Member newMember = new Member();
             
            return View("Index", newMember);
        }

        public IActionResult SaveMemberParams(Member newMember)
        {
            MemberServices memberService = new MemberServices();


            string returnValue = memberService.SaveMember(newMember);

            if (returnValue.Equals("success"))
            {

                HttpContext.Session.SetInt32("memberId", newMember.MemberId);
                
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

            if(member.OwnedGames is null)
            {
                member.OwnedGames = new List<Game>();
            }
            if(member.LikeToPlayGames is null)
            {
                member.LikeToPlayGames = new List<Game>();
            }

            member.OwnedGames = ms.GetMemberOwnedGames(memberId);

           

            GameChooseViewModel vm = new GameChooseViewModel();
            vm.member = member;
            return View("GameSelectionPage", vm);
        }

        public IActionResult GetSuggestedGames(string term)
        {
            
            
            GameServices service = new GameServices(Configuration);



            List<Game> games = service.GetGameSuggestions(term).Result;

            

            return Json(games);
        }

        public IActionResult SaveMemberGames(Member member)
        {
            GameServices gameService = new GameServices(Configuration);
            MemberServices memberService = new MemberServices();

            try
            {
                gameService.SaveGamesToDatabase(member.OwnedGames);
               // gameService.SaveGamesToDatabase(member.LikeToPlayGames);

                gameService.LinkGamesOwnedToMember(member);


                return Content("success");
            }catch(Exception e)
            {
                return Content("failure");
            }
        }
    }
}
