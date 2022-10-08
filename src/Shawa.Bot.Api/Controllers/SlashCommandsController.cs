using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shawa.Bot.Api.Models.Configuration;
using Shawa.Bot.Api.Models.Requests;
using Shawa.Bot.Api.Models.Responses;
using Action = Shawa.Bot.Api.Models.Responses.Action;

namespace Shawa.Bot.Api.Controllers;

[ApiController]
[Route("api/commands")]
public class SlashCommandsController: ControllerBase
{
    private readonly ILogger<SlashCommandsController> _logger;
    private readonly IOptions<MattermostSettings> _mattermostSettings;

    public SlashCommandsController(ILogger<SlashCommandsController> logger, 
        IOptions<MattermostSettings> mattermostSettings)
    {
        _logger = logger;
        _mattermostSettings = mattermostSettings;
    }

    [HttpPost("orders")]
    public async Task<ActionResult<SlashCommandResponse>> TakeOrder([FromForm] SlashCommandRequest request)
    {
        if (_mattermostSettings.Value.Token != request.Token)
        {
            return Forbid();
        }

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
            Text = "Hello Time :peepohey: Test Actions",
            ResponseType = "ephemeral",
            Attachments = new[]
            {
                new Attachment
                {
                    Actions = new[]
                    {
                        new Action
                        {
                            Id = "action_opt",
                            Name = "test text",
                            Integration = new ActionIntegration
                            {
                                Url = $"{_mattermostSettings.Value.Url}/api/commands/answer",
                                Context = new ActionIntegrationContext
                                {
                                    Action = "do_something"
                                }
                            },
                            Type = "select",
                            Options = new[]
                            {
                                new Option
                                {
                                    Text = "One",
                                    Value = "1"
                                },
                                new Option
                                {
                                    Text = "Two",
                                    Value = "2"
                                },
                                new Option
                                {
                                    Text = "Three",
                                    Value = "3"
                                }
                            }
                        }
                    }
                }
            }
        };

        return response;
    }

    [HttpGet("answer")]
    public IActionResult SendAnswer([FromForm] object request)
    {
        _logger.LogInformation("Answer + {request}", request.ToString());

        return Ok();
    }
}