﻿using Alexa.NET.Response.Converters;
using Newtonsoft.Json;

namespace Alexa.NET.Response
{
    public class Reprompt
    {
        public Reprompt()
        {
        }

        public Reprompt(string text)
        {
            OutputSpeech = new PlainTextOutputSpeech { Text = text };
        }

        public Reprompt(Ssml.Speech speech)
        {
            OutputSpeech = new SsmlOutputSpeech { Ssml = speech.ToXml() };
        }

        [JsonProperty("outputSpeech", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(OutputSpeechConverter))]
        public IOutputSpeech OutputSpeech { get; set; }
    }
}