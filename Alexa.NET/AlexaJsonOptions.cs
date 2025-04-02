using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Alexa.NET.Response;
using Alexa.NET.Response.Directive.Templates;

namespace Alexa.NET;

public static class AlexaJsonOptions
{
    // This allows external packages to register their own JsonTypeInfo modifiers
    private static readonly List<Action<JsonTypeInfo>> AdditionalModifiers = [];

    public static JsonSerializerOptions DefaultOptions
    {
        get
        {
            var resolver = new DefaultJsonTypeInfoResolver();

            // Your base/core modifier
            resolver.Modifiers.Add(typeInfo =>
            {
                if (typeInfo.Type == typeof(ResponseBody))
                {
                    var prop = typeInfo.Properties.FirstOrDefault(p => p.Name == "directives");
                    if (prop != null)
                    {
                        prop.ShouldSerialize = (obj, _) =>
                        {
                            var response = (ResponseBody)obj;
                            return response.Directives is { Count: > 0 };
                        };
                    }
                }
                else if (typeInfo.Type == typeof(Reprompt))
                {
                    var prop = typeInfo.Properties.FirstOrDefault(p => p.Name == "directives");
                    if (prop != null)
                    {
                        prop.ShouldSerialize = (obj, _) =>
                        {
                            var response = (Reprompt)obj;
                            return response.Directives is { Count: > 0 };
                        };
                    }
                }
                else if (typeInfo.Type == typeof(ImageSource))
                {
                    var widthProp = typeInfo.Properties.FirstOrDefault(p => p.Name == "widthPixels");
                    if (widthProp is not null)
                    {
                        widthProp.ShouldSerialize = (obj, _) =>
                        {
                            var imageSource = (ImageSource)obj;
                            return imageSource.Width > 0;
                        };
                    }
                    var heightProp = typeInfo.Properties.FirstOrDefault(p => p.Name == "heightPixels");
                    if (heightProp is not null)
                    {
                        heightProp.ShouldSerialize = (obj, _) =>
                        {
                            var imageSource = (ImageSource)obj;
                            return imageSource.Height > 0;
                        };
                    }
                }
            });

            foreach (var modifier in AdditionalModifiers)
            {
                resolver.Modifiers.Add(modifier);
            }

            return new JsonSerializerOptions
            {
                TypeInfoResolver = resolver,
                WriteIndented = true
            };
        }
    }
    
    public static void RegisterTypeModifier<T>(Action<JsonTypeInfo> modifier)
    {
        AdditionalModifiers.Add(ti => {
            if (ti.Type == typeof(T))
            {
                modifier(ti);
            }
        });
    }
}