using Microsoft.AspNetCore.Mvc;

namespace Shawa.Bot.Api.Controllers;

[ApiController]
[Route("api/commands")]
public class SlashCommandsController
{
    private readonly ILogger<SlashCommandsController> _logger;

    public SlashCommandsController(ILogger<SlashCommandsController> logger)
    {
        _logger = logger;
    }

    [HttpPost("orders")]
    public async Task<IActionResult> TakeOrder()
    {
        throw new NotImplementedException();
    }
}