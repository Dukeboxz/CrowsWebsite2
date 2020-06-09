using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowsWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CrowsWebsite.Services
{
    public class MemberServices
    {
        DbContext db = new websiteContext();
        public string SaveMember(Member member)
        {
            try
            {
                Member alreadyThere = null;
                using (var dbo = new websiteContext())
                {
                    alreadyThere = dbo.Members.FirstOrDefault(m => m.MemberId == member.MemberId);
                }
               
                if(alreadyThere is null)
                {
                    db.Add<Member>(member);
                }
                else
                {
                    db.Update(member);
                }

                
                db.SaveChanges();

                return "success"; 

            }catch(Exception e)
            {
                return "failure"; 
            }
        }

        public Member GetMemberById(int id)
        {
            Member member = null;

            try
            {
                using (var dbo = new websiteContext())
                {
                    member = dbo.Members.FirstOrDefault(m => m.MemberId == id);
                }
            }catch(Exception e)
            {
                return member;
            }

            return member;
        }

        public List<Game> GetMemberOwnedGames(int memberId)
        {
            try
            {
                List<Game> games;
                using (var dbo = new websiteContext())
                {
                    games = dbo.MemberOwnedGames
                        .Where(x => x.MemberId == memberId)
                        .Select(x => x.Game).ToList();

                }

                return games;
            }catch(Exception e)
            {
                throw new Exception("Could not get want to play games");
            }
          
        }

        public List<Game> GetMemberLikeToPlayGames(int memberId)
        {
            List<Game> games;

            try
            {

                using (var dbo = new websiteContext())
                {
                    games = dbo.MemberLikeToPlayGames
                        .Where(x => x.MemberId == memberId)
                        .Select(x => x.Game).ToList();
                }

                return games;
            }catch(Exception e)
            {
                throw new Exception("could not get member like to play games");
            }



        }
    }
}
