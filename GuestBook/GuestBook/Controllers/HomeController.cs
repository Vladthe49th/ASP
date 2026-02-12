using GuestBook.Data;
using GuestBook.Models;
using GuestBook.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace GuestBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly GuestBookContext _context;

        public HomeController(GuestBookContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _context.Messages
                .Include(m => m.User)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();

            return View(messages);
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

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }




    }
}
