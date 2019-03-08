using System;
using Microsoft.EntityFrameworkCore;
using static MoviesApp.Models.FilmGenre;

namespace MoviesApp.Models
{
    public class DataInitializer
    {
        static int personId = 0;
        private static Person p(string name)
        {
            return new Person {
                PersonId = ++personId,
                Name = name
            };
        }

        public static void Initialize(ModelBuilder modelBuilder)
        {
            // Default values
            Person[] persons = {

                // Game of Thrones
                p("Алан Тейлор"),
                p("Питер Динклейдж"),  // Actor
                p("Шон Бин"),

                p("Чак Рассел"),
                p("Джим Керри"),
                p("Питер Ригерт"),
                
                p("Фрэнк Дарабонт"),
                p("Тим Роббинс"),
                p("Морган Фриман"),

                p("Люк Бессон"),
                p("Натали Портман"),
                p("Жан Рено"),

                p("Пол Макгиган"),
                p("Будапешт Киберскотч"),
                p("Мартин Фримен"),
                
                p("Оливье Накаш"),
                p("Франсуа Клюзе"),
                p("Омар Си"),

                p("Роберт Земекис"),
                p("Майкл Фокс"),
                p("Кристофер Ллойд")
            };

            Film[] films = {
                new Film {
                    FilmId = 1,
                    Title = "Игра престолов",
                    ReleaseYear = 2011,
                    Genre = Fantasy,
                    Description = "Описание \"Игры престолов\"",
                    PosterPath = "/img/posters/1.jpeg"
                },

                new Film {
                    FilmId = 2,
                    Title = "Маска",
                    ReleaseYear = 1994,
                    Genre = Comedy,
                    Description = "Описание \"Маски\"",
                    PosterPath = "/img/posters/2.jpg"
                },

                new Film {
                    FilmId = 3,
                    Title = "Побег из Шоушенка",
                    ReleaseYear = 1994,
                    Genre = Drama,
                    Description = "Описание \"Побега из Шоушенка\"",
                    PosterPath = "/img/posters/3.jpg"
                },

                new Film {
                    FilmId = 4,
                    Title = "Леон",
                    ReleaseYear = 1994,
                    Genre = Drama,
                    Description = "Описание \"Леона\"",
                    PosterPath = "/img/posters/4.jpg"
                },

                new Film {
                    FilmId = 5,
                    Title = "Шерлок",
                    ReleaseYear = 2010,
                    Genre = Detective,
                    Description = "Описание \"Шерлока\"",
                    PosterPath = "/img/posters/5.jpg"
                },

                new Film {
                    FilmId = 6,
                    Title = "1+1",
                    ReleaseYear = 2011,
                    Genre = Drama,
                    Description = "Описание \"1+1\"",
                    PosterPath = "/img/posters/6.jpg"
                },

                new Film {
                    FilmId = 7,
                    Title = "Назад в будущее",
                    ReleaseYear = 1985,
                    Genre = ScienceFiction,
                    Description = "Описание \"Назад в будущее\"",
                    PosterPath = "/img/posters/7.jpg"
                }
            };
            modelBuilder.Entity<Person>().HasData(persons);
            modelBuilder.Entity<Film>().HasData(films);
            modelBuilder.Entity<FilmDirectorJoin>().HasData(
                new FilmDirectorJoin {
                    FilmId = films[0].FilmId,
                    PersonId = persons[0].PersonId
                },
                new FilmDirectorJoin {
                    FilmId = films[1].FilmId,
                    PersonId = persons[3].PersonId
                },
                new FilmDirectorJoin {
                    FilmId = films[2].FilmId,
                    PersonId = persons[6].PersonId
                },
                new FilmDirectorJoin {
                    FilmId = films[3].FilmId,
                    PersonId = persons[9].PersonId
                },
                new FilmDirectorJoin {
                    FilmId = films[4].FilmId,
                    PersonId = persons[12].PersonId
                },
                new FilmDirectorJoin {
                    FilmId = films[5].FilmId,
                    PersonId = persons[15].PersonId
                },
                new FilmDirectorJoin {
                    FilmId = films[6].FilmId,
                    PersonId = persons[18].PersonId
                }
            );
            modelBuilder.Entity<FilmActorJoin>().HasData(
                new FilmActorJoin {
                    FilmId = films[0].FilmId,
                    PersonId = persons[1].PersonId
                },
                new FilmActorJoin {
                    FilmId = films[0].FilmId,
                    PersonId = persons[2].PersonId
                },

                new FilmActorJoin {
                    FilmId = films[1].FilmId,
                    PersonId = persons[4].PersonId
                },
                new FilmActorJoin {
                    FilmId = films[1].FilmId,
                    PersonId = persons[5].PersonId
                },

                new FilmActorJoin {
                    FilmId = films[2].FilmId,
                    PersonId = persons[7].PersonId
                },
                new FilmActorJoin {
                    FilmId = films[2].FilmId,
                    PersonId = persons[8].PersonId
                },

                new FilmActorJoin {
                    FilmId = films[3].FilmId,
                    PersonId = persons[10].PersonId
                },
                new FilmActorJoin {
                    FilmId = films[3].FilmId,
                    PersonId = persons[11].PersonId
                },

                new FilmActorJoin {
                    FilmId = films[4].FilmId,
                    PersonId = persons[13].PersonId
                },
                new FilmActorJoin {
                    FilmId = films[4].FilmId,
                    PersonId = persons[14].PersonId
                },

                new FilmActorJoin {
                    FilmId = films[5].FilmId,
                    PersonId = persons[16].PersonId
                },
                new FilmActorJoin {
                    FilmId = films[5].FilmId,
                    PersonId = persons[17].PersonId
                },

                new FilmActorJoin {
                    FilmId = films[6].FilmId,
                    PersonId = persons[19].PersonId
                },

                new FilmActorJoin {
                    FilmId = films[6].FilmId,
                    PersonId = persons[20].PersonId
                }
            );
        }
    }
}