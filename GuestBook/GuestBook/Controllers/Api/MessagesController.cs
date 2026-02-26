using GuestBook.BLL.Interfaces;
using GuestBook.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GuestBook.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: api/messages
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _messageService.GetAllMessagesAsync();
            return Ok(messages);
        }

        // POST: api/messages
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateMessageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Text))
                return BadRequest("Message cannot be empty");

            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!
            );

            await _messageService.AddMessageAsync(request.Text, userId);

            return Ok();
        }
    }
}