using System.Text.Json;

namespace Pure.Library.Extensions;

public static class ObjectExtensions
{
    public static bool JsonComparator(this object original, object comparisomObject)
    {
        string jsonOriginal = JsonSerializer.Serialize(original);
        string jsonComparisom = JsonSerializer.Serialize(comparisomObject);

        return jsonOriginal.Equals(jsonComparisom);
    }
}
