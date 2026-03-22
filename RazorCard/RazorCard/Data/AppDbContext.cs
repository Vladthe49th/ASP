using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using RazorCard.Models;



namespace RazorCard.Data { 
public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Person>().HasData(new Person
        {
            Id = 1,
            FirstName = "Vladislav",
            LastName = "Yerts",
            Email = "vlad@example.com",
            Phone = "+380000000000",
            BirthDate = new DateTime(2000, 1, 1),
            ShortBio = "Aspiring developer from Ukraine."
        });
    }
}


}