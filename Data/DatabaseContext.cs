using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetMoviesAppRazor.Data
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Review> FilmReviews { get; set; }
        public DbSet<Person> Persons { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .Property(f => f.Genre)
                .HasDefaultValue(FilmGenre.Other);
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Actors)
                .WithMany(a => a.ActoredFilms);
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Directors)
                .WithMany(d => d.DirectoredFilms);
            modelBuilder.Entity<User>()
                .HasMany(u => u.FavouriteFilms)
                .WithMany(f => f.FavouriteOfUsers);

            DataInitializer.Initialize(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    } // class
} // namespace