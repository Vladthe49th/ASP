
using RazorCard.Models;

namespace RazorCard.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> GetFirstAsync();
    }
}
