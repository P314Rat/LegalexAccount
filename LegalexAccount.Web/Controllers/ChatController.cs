﻿using Microsoft.AspNetCore.Mvc;


namespace LegalexAccount.Web.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        //private readonly AppDbContext _context;
        //private readonly IHubContext<ChatHub> _hubContext;

        //public ChatController(AppDbContext context, IHubContext<ChatHub> hubContext)
        //{
        //    _context = context;
        //    _hubContext = hubContext;
        //}

        //[HttpPost("send")]
        //public async Task<IActionResult> SendMessage([FromBody] SendMessageDto dto)
        //{
        //    var message = new Message
        //    {
        //        ChatId = dto.ChatId,
        //        SenderId = dto.SenderId,
        //        Content = dto.Content
        //    };

        //    _context.Messages.Add(message);
        //    await _context.SaveChangesAsync();

        //    // Отправка в SignalR
        //    await _hubContext.Clients.Group(dto.ChatId.ToString()).SendAsync("ReceiveMessage", dto.SenderId, dto.Content);

        //    return Ok();
        //}

        //[HttpGet("{chatId}/messages")]
        //public async Task<IActionResult> GetMessages(Guid chatId)
        //{
        //    var messages = await _context.Messages
        //        .Where(m => m.ChatId == chatId)
        //        .OrderBy(m => m.CreatedAt)
        //        .ToListAsync();

        //    return Ok(messages);
        //}
    }
}
