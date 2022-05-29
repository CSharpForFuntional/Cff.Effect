using System.Reflection;
using System.Text.Json;
using Cff.Effect.Abstractions;

namespace Cff.Effect.Json;

internal readonly record struct Json(JsonSerializerOptions JsonSerializerOptions) : IJson
{
    public string Serialize<T>(T msg) where T : notnull
    {
        var assembly = msg.GetType().Assembly.GetName().Name;
        var type = msg.GetType().FullName!;

        return @$"{{""A"":""{assembly}"",""T"":""{type}"",""V"":{JsonSerializer.Serialize(msg, JsonSerializerOptions)}}}";
    }

    public Task<object?> DeserializeAsync(Stream stream, CancellationToken ct)
    {
        var q = (JsonSerializerOptions option) =>
            from doc in JsonDocument.ParseAsync(stream, cancellationToken: ct)
            let root = doc.RootElement
            let assembly = root.GetProperty("A").GetString()
            let typeName = root.GetProperty("T").GetString()
            let type = Assembly.Load(assembly).GetType(typeName)
            select root.GetProperty("V").Deserialize(type, option);

        return q(JsonSerializerOptions);
    }

    public object? Deserialize(string jsonString)
    {
        var root = JsonDocument.Parse(jsonString).RootElement;

        var assembly = root.GetProperty("A").GetString();
        var typeName = root.GetProperty("T").GetString();

        var type = Assembly.Load(assembly!).GetType(typeName!);

        return root.GetProperty("V").Deserialize(type!, JsonSerializerOptions);
    }
}

