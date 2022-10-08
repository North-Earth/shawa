using Microsoft.AspNetCore.Mvc;
using Shawa.Bot.Api.Models.Requests;
using Shawa.Bot.Api.Models.Responses;

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
    public async Task<ActionResult<SlashCommandResponse>> TakeOrder([FromForm] SlashCommandRequest request)
    {
        _logger.LogInformation(
            "Command: {command}\n" +
            "Text: {text}\n" +
            "Token: {token}\n" +
            "ChannelId: {channelId}\n" +
            "ChannelMentions: {channelMentions}\n" +
            "ChannelName: {channelName}\n" +
            "ResponseUrl: {responseUrl}\n" +
            "TeamId: {teamId}\n" +
            "TriggerId: {triggerId}\n" +
            "UserId: {userId}\n" +
            "UserMentions: {userMentions}\n" +
            "UserName: {userName}\n" +
            "ChannelMentionsIds: {channelMentionsIds}\n" +
            "UserMentionsIds: {userMentionsIds} \n", 
            request.Command, request.Text, request.Token, 
            request.ChannelId, string.Join(",", request.ChannelMentions ?? Array.Empty<string?>()), 
            request.ChannelName, request.ResponseUrl, request.TeamId, request.TriggerId,
            request.UserId, string.Join(",", request.UserMentions ?? Array.Empty<string?>()), 
            request.UserName, string.Join(",", request.ChannelMentionsIds ?? Array.Empty<string?>()), 
            string.Join(",", request.UserMentionsIds ?? Array.Empty<string?>()));

        var response = new SlashCommandResponse
        {
            Text = "Hello Time :peepohey:",
            ResponseType = "ephemeral",
        };

        return response;
    }
}