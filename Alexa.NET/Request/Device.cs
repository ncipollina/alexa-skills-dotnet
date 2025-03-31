﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Alexa.NET.Request;

public class Device
{
    [JsonProperty("deviceId")]
    public string DeviceID { get; set; }

    [JsonProperty("supportedInterfaces")]
    public Dictionary<string, object> SupportedInterfaces { get; set; }

    public bool IsInterfaceSupported(string interfaceName)
    {
        var hasInterface = SupportedInterfaces?.ContainsKey(interfaceName);
        return (hasInterface.HasValue ? hasInterface.Value : false); 
    }

    [JsonProperty("persistentEndpointId",NullValueHandling = NullValueHandling.Ignore)]
    public string PersistentEndpointID { get; set; }
}