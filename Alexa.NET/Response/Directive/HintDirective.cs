﻿using System.Text.Json.Serialization;
using Alexa.NET.Response.Directive.Templates;

namespace Alexa.NET.Response.Directive;

public class HintDirective:IDirective
{
    public const string DirectiveType = "Hint";

    public HintDirective()
    {
    }

    public HintDirective(string hintText, string textType = TextType.Plain)
    {
        Hint = new Hint(hintText, textType);
    }

    [JsonPropertyName("type")]
    public string Type => DirectiveType;
        
    [JsonPropertyName("hint")]
    public Hint Hint { get; set; }
}