using System.Text.Json.Serialization;

namespace Shawa.Bot.Api.Models.Responses;

public class SlashCommandResponse
{
    [JsonPropertyName("response_type")]
    public string? ResponseType { get; set; }
    
    [JsonPropertyName("text")]
    public string? Text { get; set; }
    
    [JsonPropertyName("username")]
    public string? UserName { get; set; }
    
    [JsonPropertyName("channelId")]
    public string? ChannelId { get; set; }
    
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }
    
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    
    public Attachment[]? Attachments { get; set; }
}

public class Attachment
{
    [JsonPropertyName("fallback")]
    public string? Fallback { get; set; }
    
    [JsonPropertyName("color")]
    public string? Color { get; set; }
    
    [JsonPropertyName("author_name")]
    public string? AuthorName { get; set; }
    
    [JsonPropertyName("author_icon")]
    public string? AuthorIcon { get; set; }
    
    [JsonPropertyName("author_link")]
    public string? AuthorLink { get; set; }
    
    [JsonPropertyName("pretext")]
    public string? Pretext { get; set; }
    
    [JsonPropertyName("text")]
    public string? Text { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("title_link")]
    public string? TitleLink { get; set; }
    
    [JsonPropertyName("fields")]
    public Field[]? Fields { get; set; }
    
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("actions")]
    public Action[]? Actions { get; set; }
}

public class Field
{
    [JsonPropertyName("short")]
    public bool? Short { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}

public class Action
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("integration")]
    public ActionIntegration? Integration { get; set; }

    [JsonPropertyName("type")]    
    public string? Type { get; set; }
    
    [JsonPropertyName("options")]   
    public Option[]? Options { get; set; }
}

public class ActionIntegration
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }
    
    [JsonPropertyName("context")]
    public ActionIntegrationContext? Context { get; set; }
    
}

public class ActionIntegrationContext
{
    [JsonPropertyName("action")]
    public string? Action { get; set; }
}

public class Option
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
    
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}