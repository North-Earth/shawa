using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Shawa.Bot.Api.Models.Requests;

public class SlashCommandRequest
{
    [BindProperty(Name = "channel_id", SupportsGet = true)]
    [JsonPropertyName("channel_id")]
    public string? ChannelId { get; set; }
    
    [BindProperty(Name = "channel_name", SupportsGet = true)]
    [JsonPropertyName("channel_name")]
    public string? ChannelName { get; set; }
    
    [BindProperty(Name = "command", SupportsGet = true)]
    [JsonPropertyName("command")]
    public string? Command { get; set; }
    
    [BindProperty(Name = "response_url", SupportsGet = true)]
    [JsonPropertyName("response_url")]
    public string? ResponseUrl { get; set; }
    
    [BindProperty(Name = "team_id", SupportsGet = true)]
    [JsonPropertyName("team_id")]
    public string? TeamId { get; set; }
    
    [BindProperty(Name = "text", SupportsGet = true)]
    [JsonPropertyName("text")]
    public string? Text { get; set; }
    
    [BindProperty(Name = "token", SupportsGet = true)]
    [JsonPropertyName("token")]
    public string? Token { get; set; }
    
    [BindProperty(Name = "trigger_id", SupportsGet = true)]
    [JsonPropertyName("trigger_id")]
    public string? TriggerId { get; set; }
    
    [BindProperty(Name = "user_id", SupportsGet = true)]
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }
    
    [BindProperty(Name = "user_name", SupportsGet = true)]
    [JsonPropertyName("user_name")]
    public string? UserName { get; set; }
    
    [BindProperty(Name = "channel_mentions", SupportsGet = true)]
    [JsonPropertyName("channel_mentions")]
    public string[]? ChannelMentions { get; set; }
    
    [BindProperty(Name = "channel_mentions_ids", SupportsGet = true)]
    [JsonPropertyName("channel_mentions_ids")]
    public string[]? ChannelMentionsIds { get; set; }
    
    [BindProperty(Name = "user_mentions", SupportsGet = true)]
    [JsonPropertyName("user_mentions")]
    public string[]? UserMentions { get; set; }
    
    [BindProperty(Name = "user_mentions_ids", SupportsGet = true)]
    [JsonPropertyName("user_mentions_ids")]
    public string[]? UserMentionsIds { get; set; }
}