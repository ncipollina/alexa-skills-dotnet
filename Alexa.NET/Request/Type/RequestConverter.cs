﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alexa.NET.Request.Type.Converters;

namespace Alexa.NET.Request.Type;

public class RequestConverter : JsonConverter<Request>
{
    public static readonly List<IRequestTypeResolver> RequestTypeResolvers =
    [
        ..new IRequestTypeResolver[]
        {
            new DefaultRequestTypeResolver(),
            new AudioPlayerRequestTypeResolver(),
            new PlaybackRequestTypeResolver(),
            new TemplateEventRequestTypeResolver(),
            new SkillEventRequestTypeResolver(),
            new SkillConnectionRequestTypeResolver(),
            new ConnectionResponseTypeResolver()
        }
    ];

    public override bool CanConvert(System.Type objectType)
    {
        return objectType == typeof(Request);
    }

    public override Request? Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var root = document.RootElement;
        if (!root.TryGetProperty("type", out var typeProp))
        {
            throw new JsonException("Missing 'type' property in request.");
        }

        var requestType = typeProp.GetString();
        if (string.IsNullOrWhiteSpace(requestType))
        {
            throw new JsonException("'type' property is null or empty.");
        }
       
        var typeResolver = RequestTypeResolvers.FirstOrDefault(c => c.CanResolve(requestType));

        if (typeResolver is null)
        {
            throw new ArgumentOutOfRangeException(nameof(requestType), $"Unknown request type: {requestType}.");
        }
        var target = typeResolver switch
        {
            null => throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown request type: {requestType}."),
            IDataDrivenRequestTypeResolver dataDriven => dataDriven.Resolve(root),
            _ => typeResolver.Resolve(requestType)
        };
        var json = root.GetRawText();
        return (Request?)JsonSerializer.Deserialize(json, target, options);
    }

    public override void Write(Utf8JsonWriter writer, Request value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}