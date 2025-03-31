using System;
using System.Collections.Generic;
using System.Text.Json;
using Alexa.NET.Response.Directive;

namespace Alexa.NET.Response.Converters;

public class DirectiveConverter : BasePolymorphicConverter<IDirective>
{
    public static IDictionary<string, Type> DirectiveDeriveTypes = new Dictionary<string, Type>
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
        { "Tasks.CompleteTask", typeof(CompleteTaskDirective) },
        { DialogUpdateDynamicEntities.DirectiveType, typeof(DialogUpdateDynamicEntities) }
    };
    
    public static Dictionary<string, Func<JsonElement, Type>> DirectiveDataDrivenTypeFactories =
        new Dictionary<string, Func<JsonElement, Type>>
        {
            {"Connections.SendRequest", ConnectionSendRequestFactory.Create}
        };
    
    // public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    // {
    //     var jsonObject = JObject.Load(reader);
    //     var typeKey = jsonObject["type"] ?? jsonObject["Type"];
    //     var typeValue = typeKey.Value<string>();
    //     var hasTypeFactory = TypeFactories.ContainsKey(typeValue);
    //     var dataTypeFactory = DirectiveDataDrivenTypeFactories.ContainsKey(typeValue);
    //
    //     IDirective directive;
    //
    //     if (hasTypeFactory)
    //     {
    //         directive = TypeFactories[typeValue]();
    //     }
    //     else if(dataTypeFactory)
    //     {
    //         directive = DirectiveDataDrivenTypeFactories[typeValue](jsonObject);
    //     }
    //     else
    //     {
    //         directive = new JsonDirective(typeValue);
    //     }
    //
    //     serializer.Populate(jsonObject.CreateReader(), directive);
    //
    //     return directive;
    // }
    //
    // public override bool CanConvert(Type objectType)
    // {
    //     return objectType == typeof(IDirective);
    // }

    protected override string TypeDiscriminatorPropertyName => "type";

    protected override IDictionary<string, Type> DerivedTypes => DirectiveDeriveTypes;

    protected override IDictionary<string, Func<JsonElement, Type>> DataDrivenTypeFactories => DirectiveDataDrivenTypeFactories;


    public override Type? DefaultType => typeof(JsonDirective);
}