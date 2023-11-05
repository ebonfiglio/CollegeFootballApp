using CollegeFootballApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollegeFootballApp.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamConference> TeamConferences { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining primary keys
            modelBuilder.Entity<Conference>()
                .HasKey(c => c.Name);

            modelBuilder.Entity<Conference>()
.Property(c => c.Name)
.ValueGeneratedNever();

            modelBuilder.Entity<Game>()
                .HasKey(g => g.Id);
            modelBuilder.Entity<Game>()
.Property(g => g.Id)
.ValueGeneratedNever();

            modelBuilder.Entity<Team>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Team>()
.Property(t => t.Id)
.ValueGeneratedNever();

            modelBuilder.Entity<TeamConference>()
                .HasKey(tc => new { tc.TeamId, tc.ConferenceName });


            modelBuilder.Entity<Venue>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Venue>()
       .Property(v => v.Id)
       .ValueGeneratedNever();

            // Setting up relationships

            // Game to Venue relationship
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Venue)
                .WithMany()
                .HasForeignKey(g => g.VenueId);

            // Game to TeamConference relationship for HomeTeamConference
            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeamConference)
                .WithMany()
                .HasForeignKey(g => new { g.HomeId, g.HomeConferenceName })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete/update

            // Game to TeamConference relationship for AwayTeamConference
            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeamConference)
                .WithMany()
                .HasForeignKey(g => new { g.AwayTeamId, g.AwayConferenceName })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete/update

            // TeamConference relationships
            modelBuilder.Entity<TeamConference>()
                .HasOne(tc => tc.Team)
                .WithMany()
                .HasForeignKey(tc => tc.TeamId);

            modelBuilder.Entity<TeamConference>()
                .HasOne(tc => tc.Conference)
                .WithMany()
                .HasForeignKey(tc => tc.ConferenceName);


            base.OnModelCreating(modelBuilder);
        }
    }
}