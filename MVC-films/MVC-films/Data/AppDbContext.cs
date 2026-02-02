using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using System.Collections.Generic;

namespace MovieApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
