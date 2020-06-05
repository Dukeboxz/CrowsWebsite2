using System;
using System.Collections.Generic;
using CrowsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using CrowsWebsite.Services;
using Microsoft.AspNetCore.Http;
using CrowsWebsite.Models.ViewModels;
using Microsoft.AspNetCore.Razor.Language;

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
            member.ownedGames = new List<Game>();
            member.LikeToPlayGames = new List<Game>();

            Game testGame = new Game();
            testGame.name = "Test Game";
            testGame.min_players = 2;

            member.ownedGames.Add(testGame);

            GameChooseViewModel vm = new GameChooseViewModel();
            vm.member = member;
            return View("GameSelectionPage", vm);
        }

        public IActionResult GetSuggestedGames(string term)
        {
            int test = 5;

           List<Game> games = new List<Game>();

            Game game1 = new Game();
            game1.name = "Awesome Game";
            game1.Id = 1;
            games.Add(game1);

            Game game2 = new Game();
            game2.name = "Not so good game";
            game2.Id = 2;
            games.Add(game2);

            return Json(games);
        }
    }
}
