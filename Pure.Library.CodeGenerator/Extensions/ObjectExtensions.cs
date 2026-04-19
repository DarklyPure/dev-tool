using System.Text.Json;

namespace Pure.Library.CodeGenerator.Extensions;

/// <summary>
/// Extensions to the type <see cref="object"/>.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Compares the original object with the comparisom passed.
    /// </summary>
    /// <param name="original">The original object.</param>
    /// <param name="comparisomObject">The object being compared to.</param>
    /// <returns>Returns true if the objects are identical.</returns>
    public static bool JsonComparator(this object original, object comparisomObject)
    {
        string jsonOriginal = JsonSerializer.Serialize(original);
        string jsonComparisom = JsonSerializer.Serialize(comparisomObject);

        return jsonOriginal.Equals(jsonComparisom);
    }
}
