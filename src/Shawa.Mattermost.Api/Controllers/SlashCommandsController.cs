using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shawa.Bot.Api.Models.Requests;
using Shawa.Bot.Api.Models.Responses;
using Shawa.Mattermost.Api.Models.Configuration;
using Action = Shawa.Bot.Api.Models.Responses.Action;

namespace Shawa.Mattermost.Api.Controllers;

[ApiController]
[Route("api/commands")]
public class SlashCommandsController : ControllerBase
{
    private readonly ILogger<SlashCommandsController> _logger;
    private readonly IOptions<MattermostSettings> _mattermostSettings;

    public SlashCommandsController(ILogger<SlashCommandsController> logger, 
        IOptions<MattermostSettings> mattermostSettings)
    {
        _logger = logger;
        _mattermostSettings = mattermostSettings;
    }
    
    [HttpGet("{commandId}")]
    public async Task<ActionResult<SlashCommandResponse>> GetCommandResult(string commandId, 
        [FromHeader] SlashCommandRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Test()
    {
        // using (var ws = new ClientWebSocket())
        // {
        //     await ws.ConnectAsync(new Uri("wss:/ /api/v4/websocket"), default);
        //     ws.SendAsync();
        // }

        throw new NotImplementedException();
    }
    
    [HttpPost("friday")]
    public async Task<ActionResult<SlashCommandResponse>> TakeOrder2([FromForm] SlashCommandRequest request)
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
        
        // if (_mattermostSettings.Value.Token != request.Token)
        // {
        //     return Forbid();
        // }

        var response = new SlashCommandResponse
        {
            ResponseType = "in_channel",
            Attachments = new []
            {
                new Attachment
                {
                    Text = "Hello Time!",
                    Actions = new []
                    {
                        new Action
                        {
                            Id = "action_options",
                            Name = "Select an option...",
                            Integration = new ActionIntegration
                            {
                                Url = $"{_mattermostSettings.Value.Url}/friday/answer",
                                Context = new ActionIntegrationContext()
                                {
                                    Action = "do_something"
                                }
                            },
                            Type = "select",
                            Options = new []
                            {
                                new Option
                                {
                                    Text = "Option1",
                                    Value = "opt1"
                                },
                                new Option
                                {
                                    Text = "Option2",
                                    Value = "opt2"
                                },
                                new Option
                                {
                                    Text = "Option3",
                                    Value = "opt3"
                                },
                            },
                        },
                        new Action
                        {
                            Id = "message",
                            Name = "Ephemeral Message",
                            Integration = new ActionIntegration
                            {
                                Url = $"{_mattermostSettings.Value.Url}/friday/answer",
                                Context = new ActionIntegrationContext
                                {
                                    Action = "do_something_ephemeral"
                                }
                            }
                        },
                        new Action
                        {
                            Id = "update",
                            Name = "Update",
                            Integration = new ActionIntegration
                            {
                                Url = $"{_mattermostSettings.Value.Url}/friday/answer",
                                Context = new ActionIntegrationContext
                                {
                                    Action = "do_something_update"
                                }
                            }
                        }
                    }
                }
            }
        };

        return Ok(response);
    }
    
    [HttpGet("friday")]
    public async Task<ActionResult<SlashCommandResponse>> TakeOrder([FromHeader] SlashCommandRequest request)
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

        // if (_mattermostSettings.Value.Token != request.Token)
        // {
        //     return Forbid();
        // }

        var response = new SlashCommandResponse
        {
            ResponseType = "in_channel",
            Attachments = new []
            {
                new Attachment
                {
                    Text = "Hello Time!",
                    Actions = new []
                    {
                        new Action
                        {
                            Id = "action_options",
                            Name = "Select an option...",
                            Integration = new ActionIntegration
                            {
                                Url = $"{_mattermostSettings.Value.Url}/friday/answer",
                                Context = new ActionIntegrationContext()
                                {
                                    Action = "do_something"
                                }
                            },
                            Type = "select",
                            Options = new []
                            {
                                new Option
                                {
                                    Text = "Option1",
                                    Value = "opt1"
                                },
                                new Option
                                {
                                    Text = "Option2",
                                    Value = "opt2"
                                },
                                new Option
                                {
                                    Text = "Option3",
                                    Value = "opt3"
                                },
                            },
                        },
                        new Action
                        {
                            Id = "message",
                            Name = "Ephemeral Message",
                            Integration = new ActionIntegration
                            {
                                Url = $"{_mattermostSettings.Value.Url}/friday/answer",
                                Context = new ActionIntegrationContext
                                {
                                    Action = "do_something_ephemeral"
                                }
                            }
                        },
                        new Action
                        {
                            Id = "update",
                            Name = "Update",
                            Integration = new ActionIntegration
                            {
                                Url = $"{_mattermostSettings.Value.Url}/friday/answer",
                                Context = new ActionIntegrationContext
                                {
                                    Action = "do_something_update"
                                }
                            }
                        }
                    }
                }
            }
        };

        return Ok(response);
    }
    
    [HttpGet("friday/answer")]
    public IActionResult SendAnswer2()
    {
        _logger.LogInformation("Friday GET answer!");
        return Ok();
    }
    
    [HttpPost("friday/answer")]
    public IActionResult SendAnswer()
    {
        _logger.LogInformation("Friday POST answer!");
        return Ok();
    }
}
