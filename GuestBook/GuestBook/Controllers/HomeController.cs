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
        private readonly IRepository<Message> _messageRepository;

        public HomeController(IRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _messageRepository.GetAllAsync();

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

            var message = new Message
            {
                Text = model.Text,
                CreatedAt = DateTime.Now,
                UserId = userId
            };

            await _messageRepository.AddAsync(message);
            await _messageRepository.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}