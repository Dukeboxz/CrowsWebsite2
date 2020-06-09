using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public DbSet<MemberOwnedGames> MemberOwnedGames { get; set; }

        public DbSet<MemberLikeToPlayGames> MemberLikeToPlayGames { get; set; }

        public DbSet<GamingSession> GamingSessions { get; set; }
        public DbSet<GamesBeingPlayed> GamesBeingPlayed { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=crowsWebsiteDB2;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberOwnedGames>()
                .HasKey(mog => new { mog.MemberId, mog.GameId });
            modelBuilder.Entity<MemberOwnedGames>()
                .HasOne(mog => mog.Member)
                .WithMany(m => m.MemberOwnedGames)
                .HasForeignKey(mog => mog.MemberId);
            modelBuilder.Entity<MemberOwnedGames>()
                .HasOne(mog => mog.Game)
                .WithMany(g => g.MemberOwnedGames)
                .HasForeignKey(mog => mog.GameId);

            modelBuilder.Entity<MemberLikeToPlayGames>()
                .HasKey(mltp => new { mltp.MemberId, mltp.GameId });
            modelBuilder.Entity<MemberLikeToPlayGames>()
                .HasOne(mltp => mltp.Member)
                .WithMany(m => m.MemberLikeToPlayGames)
                .HasForeignKey(mltp => mltp.MemberId);
            modelBuilder.Entity<MemberLikeToPlayGames>()
                .HasOne(mltp => mltp.Game)
                .WithMany(g => g.MemberLikeToPlayGames)
                .HasForeignKey(mltp => mltp.GameId);
        }
    }
}
