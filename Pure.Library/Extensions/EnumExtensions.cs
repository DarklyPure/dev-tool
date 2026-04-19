namespace Pure.Library.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Returns the name value of the extended Enum value, with underscores replaced by spaces
    /// </summary>
    /// <typeparam name="T">The enum type</typeparam>
    /// <param name="value">The enum value</param>
    /// <returns>The name of enum with underscores replaced by space</returns>
    public static string GetNameValue<T>(this T value) => Enum.GetName(typeof(T), value!)!.Replace("_", " ");

    /// <summary>
    /// Returns the emun collection as a dictionary.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <returns>A Dictionary translation of the enum collection.</returns>
    public static Dictionary<int, string> EnumToDictionary<T>() where T : Enum => Enum.GetValues(typeof(T))
        .Cast<T>()
        .ToDictionary(t => Convert.ToInt32(t), t => t.ToString());
}
