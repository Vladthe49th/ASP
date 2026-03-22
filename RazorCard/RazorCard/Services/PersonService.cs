
using RazorCard.Models;
using RazorCard.Repositories.Interfaces;
using RazorCard.Services.Interfaces;


namespace RazorCard.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person?> GetPersonAsync()
        {
            return await _repository.GetFirstAsync();
        }
    }
}
