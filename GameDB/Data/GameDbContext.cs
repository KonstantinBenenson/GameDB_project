using GameDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDB.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre_Game>()
                .HasOne(g => g.Genre)
                .WithMany(gg => gg.Genre_Games)
                .HasForeignKey(fk => fk.GenreId);

            modelBuilder.Entity<Genre_Game>()
                .HasOne(g => g.Game)
                .WithMany(gg => gg.Genre_Games)
                .HasForeignKey(fk => fk.GameId);

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Arcade"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Shooter"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Strategy"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Race"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Sport"
                },
                new Genre
                {
                    Id = 7,
                    Name = "RPG"
                }
                );
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameStudio> Studios { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Genre_Game> Genres_Games { get; set; }
    }
}
