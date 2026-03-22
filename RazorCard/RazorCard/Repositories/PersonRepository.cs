using Microsoft.EntityFrameworkCore;
using RazorCard.Data;
using RazorCard.Models;
using RazorCard.Repositories.Interfaces;


namespace RazorCard.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Person?> GetFirstAsync()
        {
            return await _context.Persons.FirstOrDefaultAsync();
        }
    }
}
