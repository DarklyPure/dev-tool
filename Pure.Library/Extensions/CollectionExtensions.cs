namespace Pure.Library.Extensions;

public static class CollectionExtensions
{
    /// <summary>
    /// Compares two list of strings returning only items that are new
    /// </summary>
    /// <param name="existing"></param>
    /// <param name="comparisomList"></param>
    /// <returns></returns>
    public static List<T> TakeNew<T>(this List<T> existing, List<T> comparisomList)
    {
        if (existing == null || comparisomList == null) return [];

        if (existing.Count == comparisomList.Count) { return [.. existing.Except(comparisomList)]; }

        if (existing.Count > comparisomList.Count) { return [.. existing.Except(comparisomList)]; }

        return [.. comparisomList.Except(existing).ToList()];
    }

    private static Random _random = new();

    /// <summary>
    /// Gets a random item from the array.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the array.</typeparam>
    /// <param name="array">The array.</param>
    /// <returns>A random single item from the array.</returns>
    public static T GetRandom<T>(this T[] array) => array[_random.Next(0, array.Length)];
}
