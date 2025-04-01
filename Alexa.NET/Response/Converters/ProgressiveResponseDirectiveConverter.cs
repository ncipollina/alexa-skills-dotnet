using System;
using System.Collections.Generic;
using System.Text.Json;
using Alexa.NET.Response.Directive;

namespace Alexa.NET.Response.Converters;

public class ProgressiveResponseDirectiveConverter : BasePolymorphicConverter<IProgressiveResponseDirective>
{
    public static IDictionary<string, Type> ProgressiveResponseTypes =
        new Dictionary<string, Type>
        {
            { VoicePlayerSpeakDirective.DirectiveType, typeof(VoicePlayerSpeakDirective) }
        };
    public static IDictionary<string, Func<JsonElement, Type>> ProgressiveResponseDataDrivenTypeFactories =
        new Dictionary<string, Func<JsonElement, Type>>();

    protected override string TypeDiscriminatorPropertyName => "type";
    protected override IDictionary<string, Type> DerivedTypes => ProgressiveResponseTypes;

    
    protected override IDictionary<string, Func<JsonElement, Type>>
        DataDrivenTypeFactories => ProgressiveResponseDataDrivenTypeFactories;

    protected override Func<JsonElement, JsonSerializerOptions, IProgressiveResponseDirective?>? CustomConverter => null;
    public override Type? DefaultType => typeof(VoicePlayerSpeakDirective);
}