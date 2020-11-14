using Microsoft.EntityFrameworkCore;
using System.Linq;
using static DotnetMoviesAppRazor.Data.FilmGenre;

namespace DotnetMoviesAppRazor.Data
{
    public class DataInitializer
    {
        static int personId = 0;
        private static Person p(string name)
        {
            return new Person
            {
                PersonId = ++personId,
                Name = name
            };
        }

        public static void Initialize(ModelBuilder modelBuilder)
        {
            // Default values
            Person[] persons = {

                // Game of Thrones
                p("Alan Taylor"),
                p("Peter Hayden Dinklage"),  // Actor
                p("Sean Bean"),

                p("Chuck Russell"),
                p("Jim Carrey"),
                p("Peter Riegert"),

                p("Frank Darabont"),
                p("Tim Robbins"),
                p("Morgan Freeman"),

                p("Luc Besson"),
                p("Natalie Portman"),
                p("Jean Reno"),

                p("Paul McGuigan"),
                p("Benedict Cumberbatch"),
                p("Martin Freeman"),

                p("Olivier Nakache"),
                p("François Cluzet"),
                p("Omar Sy"),

                p("Robert Zemeckis"),
                p("Michael J. Fox"),
                p("Christopher Lloyd")
            };

            var films = new[] {
                new Film {
                    Id = 1,
                    Title = "Game of Thrones",
                    ReleaseYear = 2011,
                    Genre = Fantasy,
                    Description = "A description of \"Game of Thrones\"",
                    PosterPath = "/img/posters/1.jpeg"
                },

                new Film {
                    Id = 2,
                    Title = "The Mask",
                    ReleaseYear = 1994,
                    Genre = Comedy,
                    Description = "A description of \"The Mask\"",
                    PosterPath = "/img/posters/2.jpg"
                },

                new Film {
                    Id = 3,
                    Title = "The Shawshank Redemption",
                    ReleaseYear = 1994,
                    Genre = Drama,
                    Description = "A description of \"The Shawshank Redemption\"",
                    PosterPath = "/img/posters/3.jpg"
                },

                new Film {
                    Id = 4,
                    Title = "Léon: The Professional",
                    ReleaseYear = 1994,
                    Genre = Drama,
                    Description = "A description of \"Léon: The Professional\"",
                    PosterPath = "/img/posters/4.jpg"
                },

                new Film {
                    Id = 5,
                    Title = "Sherlock",
                    ReleaseYear = 2010,
                    Genre = Detective,
                    Description = "A description of \"Sherlock\"",
                    PosterPath = "/img/posters/5.jpg"
                },

                new Film {
                    Id = 6,
                    Title = "Intouchables",
                    ReleaseYear = 2011,
                    Genre = Drama,
                    Description = "A description of \"Intouchables\"",
                    PosterPath = "/img/posters/6.jpg"
                },

                new Film {
                    Id = 7,
                    Title = "Back to the Future",
                    ReleaseYear = 1985,
                    Genre = ScienceFiction,
                    Description = "A description of \"Back to the Future\"",
                    PosterPath = "/img/posters/7.jpg"
                }
            };
            modelBuilder.Entity<Person>().HasData(persons);
            modelBuilder.Entity<Film>().HasData(films);

            var filmActorsData = Enumerable.Range(1, 7)
                .SelectMany(i => new[] {
                    new
                    {
                        ActoredFilmsId = i,
                        ActorsPersonId = 3 * (i - 1) + 2
                    },
                    new
                    {
                        ActoredFilmsId = i,
                        ActorsPersonId = 3 * (i - 1) + 3
                    }
                }).ToList();

            var filmDirectorsData = Enumerable.Range(1, 7)
                .Select(i => new
                {
                    DirectoredFilmsId = i,
                    DirectorsPersonId = 3 * (i - 1) + 1
                });

            modelBuilder.Entity("FilmPerson")
                .HasData(filmActorsData);
            modelBuilder.Entity("FilmPerson1")
                .HasData(filmDirectorsData);
        }
    }
}