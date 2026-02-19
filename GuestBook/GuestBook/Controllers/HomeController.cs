using GuestBook.Models;
using GuestBook.Repositories;
using GuestBook.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class HomeController : Controller
{
    private readonly IRepository _repository;

    public HomeController(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var messages = await _repository.GetAllMessagesAsync();

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

        await _repository.AddMessageAsync(message);

        return RedirectToAction("Index");
    }
}
