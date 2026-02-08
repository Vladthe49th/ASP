using MovieApp.Models;

namespace MovieApp.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Movies.Any())
                return;

            var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "Володар Перснів: Братство Кільця",
                    Director = "Пітер Джексон",
                    Genre = "Фентезі",
                    Year = 2001,
                    PosterPath = "/images/movies/lotr.jpg",
                    Description = "Початок великої історії про подорож, дружбу, та боротьбу зі злом.",
                    TrailerUrl = "https://www.youtube.com/embed/V75dMMIW2B4"
                },
                new Movie
                {
                    Title = "Гаррі Поттер і Таємна Кімната",
                    Director = "Кріс Коламбус",
                    Genre = "Фентезі",
                    Year = 2002,
                    PosterPath = "/images/movies/hp2.jpg",
                    Description = "Другий рік Гаррі у Гоґвортсі стає смертельно небезпечним, частково завдяки цьому маньяку Доббі...",
                    TrailerUrl = "https://www.youtube.com/embed/1bq0qff4iF8"
                },
                new Movie
                {
                    Title = "Сяйво",
                    Director = "Стенлі Кубрик",
                    Genre = "Жахи",
                    Year = 1980,
                    PosterPath = "/images/movies/shining.jpg",
                    Description = "Мила сімейна кумедія про батька, який дуже любить дружину і сина.",
                    TrailerUrl = "https://www.youtube.com/embed/S014oGZiSdI"
                },
                new Movie
                {
                    Title = "Темний Лицар",
                    Director = "Крістофер Нолан",
                    Genre = "Екшн",
                    Year = 2008,
                    PosterPath = "/images/movies/dark_knight.jpg",
                    Description = "Бетмен проти хаосу, ім'я якому Джокер.",
                    TrailerUrl = "https://www.youtube.com/embed/EXeTwQWrcwY"
                },
                new Movie
                {
                    Title = "My Little Pony: The Movie",
                    Director = "Джейсон Тіссен",
                    Genre = "Анімація",
                    Year = 2017,
                    PosterPath = "/images/movies/mlp.jpg",
                    Description = "Тому що кожному топу потрібно таке диво!",
                    TrailerUrl = "https://www.youtube.com/embed/Hn3c1FfZs84"
                },
                new Movie
                {
                    Title = "Термінатор 2: Судний день",
                    Director = "Джеймс Кемерон",
                    Genre = "Фантастика",
                    Year = 1991,
                    PosterPath = "/images/movies/t2.jpg",
                    Description = "І ВОССТАНУТЬ МАШИНИ З ПЕПЛУ ЯДЕРНОГО ВОГНЮ",
                     TrailerUrl = "https://www.youtube.com/embed/CRRlbK5w8AE"
                },
                new Movie
                {
                    Title = "Кунг-Фу Панда",
                    Director = "Марк Осборн",
                    Genre = "Анімація",
                    Year = 2008,
                    PosterPath = "/images/movies/kungfu_panda.jpg",
                    Description = "Ця битва буде легендарною!",
                     TrailerUrl = "https://www.youtube.com/embed/PXi3Mv6KMzY"
                },
                new Movie
                {
                    Title = "Походження Імператора",
                    Director = "Марк Діндал",
                    Genre = "Анімація",
                    Year = 2000,
                    PosterPath = "/images/movies/emperors_new_groove.jpg",
                    Description = "Не той ричаг, кронк!",
                    TrailerUrl = "https://www.youtube.com/watch?v=JX6btxoFhI8"
                },
                new Movie
                {
                    Title = "Розкрадачка гробниць",
                    Director = "Саймон Вест",
                    Genre = "Пригоди",
                    Year = 2001,
                    PosterPath = "/images/movies/tombraider.jpg",
                    Description = "Лара Крофт у своєму піку - во всіх сенсах",
                    TrailerUrl = "https://www.youtube.com/watch?v=VlCylyAKpGA"
                },
                new Movie
                {
                    Title = "Джуманджі",
                    Director = "Джо Джонстон",
                    Genre = "Пригоди",
                    Year = 1995,
                    PosterPath = "/images/movies/jumanji.jpg",
                    Description = "Гра, яку я б не починав.",
                    TrailerUrl = "https://www.youtube.com/watch?v=eTjDsENDZ6s"
                }
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
    }
}
