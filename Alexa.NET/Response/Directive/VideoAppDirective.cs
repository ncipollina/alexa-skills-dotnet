using System.Text.Json.Serialization;

namespace Alexa.NET.Response.Directive;

public class VideoAppDirective : IEndSessionDirective
{
    public const string DirectiveType = "VideoApp.Launch";

    public VideoAppDirective()
    {
    }

    public VideoAppDirective(string source)
    {
        VideoItem = new VideoItem(source);
    }

    [JsonPropertyName("type")] public string Type => DirectiveType;

    [JsonPropertyName("videoItem"), JsonRequired]
    public VideoItem VideoItem { get; set; }

    public bool? ShouldEndSession => null;
}