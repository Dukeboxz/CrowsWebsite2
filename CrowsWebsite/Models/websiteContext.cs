using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowsWebsite.Models
{
    public class websiteContext: DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Game> Games { get; set; }

        public DbSet<GamingSession> GamingSessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=crowsWebsiteDB2;");
        }
    }
}
