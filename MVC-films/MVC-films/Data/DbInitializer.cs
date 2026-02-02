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
                    Description = "Початок великої історії про подорож, дружбу, та протистояння силам зла"
                },
                new Movie
                {
                    Title = "Гаррі Поттер і Таємна Кімната",
                    Director = "Кріс Коламбус",
                    Genre = "Фентезі",
                    Year = 2002,
                    PosterPath = "/images/movies/hp2.jpg",
                    Description = "Другий рік Гаррі у Гоґвортсі стає смертельно небезпечним. По більшій частині через цього дурня Доббі..."
                },
                new Movie
                {
                    Title = "Сяйво",
                    Director = "Стенлі Кубрик",
                    Genre = "Жахи",
                    Year = 1980,
                    PosterPath = "/images/movies/shining.jpg",
                    Description = "Мила картина про батька, який дуже любить свою сім'ю"
                },
                new Movie
                {
                    Title = "Темний Лицар",
                    Director = "Крістофер Нолан",
                    Genre = "Екшн",
                    Year = 2008,
                    PosterPath = "/images/movies/dark_knight.jpg",
                    Description = "Бетмен проти хаосу, ім'я якому Джокер."
                },
                new Movie
                {
                    Title = "My Little Pony: The Movie",
                    Director = "Джейсон Тіссен",
                    Genre = "Анімація",
                    Year = 2017,
                    PosterPath = "/images/movies/mlp.jpg",
                    Description = "Тому що кожному топу потрібно диво"
                },
                new Movie
                {
                    Title = "Термінатор 2: Судний день",
                    Director = "Джеймс Кемерон",
                    Genre = "Фантастика",
                    Year = 1991,
                    PosterPath = "/images/movies/t2.jpg",
                    Description = "І ВОССТАНУТЬ МАШИНИ З ПЕПЛУ ЯДЕРНОГО ВОГНЮ"
                },
                new Movie
                {
                    Title = "Кунг-Фу Панда",
                    Director = "Марк Осборн",
                    Genre = "Анімація",
                    Year = 2008,
                    PosterPath = "/images/movies/kungfu_panda.jpg",
                    Description = "Наша битва буде легендарною!"
                },
                new Movie
                {
                    Title = "Походження Імператора",
                    Director = "Марк Діндал",
                    Genre = "Анімація",
                    Year = 2000,
                    PosterPath = "/images/movies/emperors_new_groove.jpg",
                    Description = "Не той ричаг, Кронк!"
                },
                new Movie
                {
                    Title = "Розкрадачка гробниць",
                    Director = "Саймон Вест",
                    Genre = "Пригоди",
                    Year = 2001,
                    PosterPath = "/images/movies/tombraider.jpg",
                    Description = "Лара Крофт у своєму піку у всіх відношеннях"
                },
                new Movie
                {
                    Title = "Джуманджі",
                    Director = "Джо Джонстон",
                    Genre = "Пригоди",
                    Year = 1995,
                    PosterPath = "/images/movies/jumanji.jpg",
                    Description = "Гра, яку я б не відкривав."
                }
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
    }
}
