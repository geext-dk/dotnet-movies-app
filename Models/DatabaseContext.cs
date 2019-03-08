using System;
using Microsoft.EntityFrameworkCore;
using static MoviesApp.Models.FilmGenre;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MoviesApp.Models
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmReview> FilmReviews { get; set; }
        public DbSet<Person> Persons { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().Property(f => f.Genre)
                .HasDefaultValue(FilmGenre.Other);
            modelBuilder.Entity<FilmActorJoin>().HasKey(fa => new { fa.PersonId, fa.FilmId });
            modelBuilder.Entity<FilmDirectorJoin>().HasKey(fd => new { fd.PersonId, fd.FilmId });
            modelBuilder.Entity<Favorite>().HasKey(f => new { f.UserId, f.FilmId });

            DataInitializer.Initialize(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    } // class
} // namespace