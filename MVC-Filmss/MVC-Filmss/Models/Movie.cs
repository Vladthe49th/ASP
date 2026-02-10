using System.ComponentModel.DataAnnotations;
using MovieApp.Validation;


namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва фільму обовʼязкова!")]
        [StringLength(100, ErrorMessage = "Назва не може перевищувати 100 символів!")]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Director { get; set; }

        [Required]
        [MaxLength(100)]
        public string Genre { get; set; }

        [NotFutureYear(ErrorMessage = "Рік фільму не може бути з майбутнього!")]
        public int Year { get; set; }


        [Url(ErrorMessage = "Некоректне посилання на постер!")]
        public string PosterPath { get; set; }

        [Required(ErrorMessage = "Опис обовʼязковий!")]
        [MinLength(20, ErrorMessage = "Опис має містити мінімум 20 символів!")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Некоректне посилання на трейлер!")]
        public string TrailerUrl { get; set; }

    }
}
