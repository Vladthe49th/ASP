using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Director { get; set; }

        [Required]
        [MaxLength(100)]
        public string Genre { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        public string PosterPath { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
