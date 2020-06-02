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
                db.Add<Member>(member);
                db.SaveChanges();

                return "success"; 

            }catch(Exception e)
            {
                return "failure"; 
            }
        }
    }
}
