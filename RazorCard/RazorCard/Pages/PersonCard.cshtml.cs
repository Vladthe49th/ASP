using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCard.Models;
using RazorCard.Services.Interfaces;


namespace RazorCard.Pages
{
    public class PersonCardModel : PageModel
    {
        private readonly IPersonService _service;

        public Person? CardPerson { get; set; }

        public PersonCardModel(IPersonService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            CardPerson = await _service.GetPersonAsync();
        }
    }
}
