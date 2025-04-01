using System.IO;
using System.Linq;
using System.Text.Json;
using JsonElement = System.Text.Json.JsonElement;
using JsonValueKind = System.Text.Json.JsonValueKind;

namespace Alexa.NET.Tests;

public static class Utility
{
    private const string ExamplesPath = "Examples";

    public static bool CompareJson(object actual, string expectedFile)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = false
        };

        // Serialize the actual object to JSON
        var actualJson = JsonSerializer.Serialize(actual, options);
        using var actualDoc = JsonDocument.Parse(actualJson);

        // Read and parse the expected JSON from file
        var expectedJson = File.ReadAllText(Path.Combine(ExamplesPath, expectedFile));
        using var expectedDoc = JsonDocument.Parse(expectedJson);

        return JsonElementDeepEquals(expectedDoc.RootElement, actualDoc.RootElement);
    }

    public static T ExampleFileContent<T>(string expectedFile)
    {
        var json = ExampleFileContent(expectedFile);
        return JsonSerializer.Deserialize<T>(json)!;
    }

    public static string ExampleFileContent(string expectedFile)
    {
        return File.ReadAllText(Path.Combine(ExamplesPath, expectedFile));
    }
    public static bool JsonElementDeepEquals(this JsonElement a, JsonElement b)
    {
        if (a.ValueKind != b.ValueKind) return false;

        switch (a.ValueKind)
        {
            case JsonValueKind.Object:
                var aProperties = a.EnumerateObject().OrderBy(p => p.Name).ToList();
                var bProperties = b.EnumerateObject().OrderBy(p => p.Name).ToList();
                if (aProperties.Count != bProperties.Count) return false;

                return !aProperties.Where((t, i) => t.Name != bProperties[i].Name ||
                                                    !t.Value.JsonElementDeepEquals(bProperties[i].Value)).Any();

            case JsonValueKind.Array:
                var aArray = a.EnumerateArray().ToList();
                var bArray = b.EnumerateArray().ToList();
                if (aArray.Count != bArray.Count) return false;

                for (var i = 0; i < aArray.Count; i++)
                {
                    if (!aArray[i].JsonElementDeepEquals(bArray[i])) return false;
                }
                return true;

            case JsonValueKind.Undefined:
            case JsonValueKind.String:
            case JsonValueKind.Number:
            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.Null:
            default:
                return a.ToString() == b.ToString();
        }
    }
}