using System;
using System.Collections.Generic;
using System.Text.Json;
using Alexa.NET.Response.Directive;

namespace Alexa.NET.Response.Converters;

public class DirectiveConverter : BasePolymorphicConverter<IDirective>
{
    public static IDictionary<string, Type> DirectiveDerivedTypes = new Dictionary<string, Type>
    {
        { AudioPlayerPlayDirective.DirectiveType, typeof(AudioPlayerPlayDirective) },
        { ClearQueueDirective.DirectiveType, typeof(ClearQueueDirective) },
        { DialogConfirmIntent.DirectiveType, typeof(DialogConfirmIntent) },
        { DialogConfirmSlot.DirectiveType, typeof(DialogConfirmSlot) },
        { DialogDelegate.DirectiveType, typeof(DialogDelegate) },
        { DialogElicitSlot.DirectiveType, typeof(DialogElicitSlot) },
        { HintDirective.DirectiveType, typeof(HintDirective) },
        { StopDirective.DirectiveType, typeof(StopDirective) },
        { VideoAppDirective.DirectiveType, typeof(VideoAppDirective) },
        { StartConnectionDirective.DirectiveType, typeof(StartConnectionDirective) },
        { CompleteTaskDirective.DirectiveType, typeof(CompleteTaskDirective) },
        { DialogUpdateDynamicEntities.DirectiveType, typeof(DialogUpdateDynamicEntities) }
    };

    public static Dictionary<string, Func<JsonElement, Type>> DirectiveDataDrivenTypeFactories =
        new()
        {
            { ConnectionSendRequest.DirectiveType, ConnectionSendRequestFactory.Create }
        };
    
    protected override string TypeDiscriminatorPropertyName => "type";

    protected override IDictionary<string, Type> DerivedTypes => DirectiveDerivedTypes;

    protected override IDictionary<string, Func<JsonElement, Type>> DataDrivenTypeFactories => DirectiveDataDrivenTypeFactories;


    protected override Func<JsonElement, JsonSerializerOptions, IDirective?>? CustomConverter => null;
    public override Type? DefaultType => typeof(JsonDirective);
}