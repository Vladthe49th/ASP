using GuestBook.BLL.Interfaces;
using GuestBook.DAL.Interfaces;
using GuestBook.DAL.Models;
using GuestBook.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GuestBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;

        public HomeController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _messageService.GetAllMessagesAsync();

            var model = new IndexViewModel
            {
                Messages = messages,
                IsAuthenticated = User.Identity?.IsAuthenticated ?? false,
                CurrentUserLogin = User.Identity?.Name
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddMessage(MessageViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!
            );

            await _messageService.AddMessageAsync(model.Text, userId);

            return RedirectToAction("Index");
        }
    }
}