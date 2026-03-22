
using RazorCard.Models;



namespace RazorCard.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person?> GetPersonAsync();
    }
}
