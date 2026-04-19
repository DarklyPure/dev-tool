using Pure.Library.Helpers;
using System.Globalization;
using System.Text;

namespace Pure.Library.Extensions;

public static class StringExtensions
{
    #region Variables
    private static TextInfo _textInfo = new CultureInfo("en-GB", false).TextInfo;
    #endregion

    #region Converters
    /// <summary>
    /// Will return the matching <see cref="Type"/> for the common name, or an <see cref="object"/> type if it can't be mapped.
    /// </summary>
    /// <param name="value">The name</param>
    /// <returns>The <see cref="Type"/> or an <see cref="object"/> type if it can't be mapped.</returns>
    /// <remarks>
    /// Useful for code generation.
    /// </remarks>
    public static Type ToTypeFromCommonName(this string value)
    {
        try
        {
            return _cSharpTypeFromName[value];
        }
        catch (Exception) { return typeof(object); }
    }

    /// <summary>
    /// <para>
    /// Splits a string, according to the delimiter passed and returns the value at the position specified.
    /// Note. This will not error if the position specified doesn't exist, it will just return an empty string.
    /// </para>
    /// </summary>
    /// <param name="value">The value to split</param>
    /// <param name="delimiter">The delimiter to split on</param>
    /// <param name="indexrequired">The index required.</param>
    /// <returns></returns>
    public static string SplitAndReturnAtPosition(this string value, char delimiter, int indexrequired)
    {
        // Split the string passed, using the delimiter
        string[] parsed = value.Split(delimiter);

        // Check that the indexrequired actually exists
        if (parsed.Length >= indexrequired - 1)
        {
            // Return the value at the index specified.
            return parsed[indexrequired];
        }
        return string.Empty;
    }

    /// <summary>
    /// Attempts to convert the value to an <see cref="int"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="int"/> if successful or the default</returns>
    public static int ToInt(this string value) => int.TryParse(value, out int convertedValue) ? convertedValue : default;

    /// <summary>
    /// Attempts to convert the value to an <see cref="int"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="int"/> if successful or the default</returns>
    public static int ToInt(this string value, int defaultValue) => int.TryParse(value, out int convertedValue) ? convertedValue : defaultValue;

    /// <summary>
    /// Attempts to convert the value to an <see cref="Nullable{int}"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="Nullable{int}"/> if successful or a null</returns>
    public static int? ToIntNullable(this string value) => int.TryParse(value, out int convertedValue) ? convertedValue : null;

    /// <summary>
    /// Attempts to convert the value to an <see cref="short"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="short"/> if successful or a default</returns>
    public static short ToShort(this string value) => short.TryParse(value, out short convertedValue) ? convertedValue : default;

    /// <summary>
    /// Attempts to convert the value to an <see cref="short"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="short"/> if successful or the default</returns>
    public static short ToShort(this string value, short defaultValue) => short.TryParse(value, out short convertedValue) ? convertedValue : defaultValue;

    /// <summary>
    /// Attempts to convert the value to an <see cref="Nullable{short}"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="Nullable{short}"/> if successful or a null</returns>
    public static short? ToShortNullable(this string value) => short.TryParse(value, out short convertedValue) ? convertedValue : null;

    /// <summary>
    /// Attempts to convert the value to an <see cref="long"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="long"/> if successful or the default</returns>
    public static long ToLong(this string value) => long.TryParse(value, out long convertedValue) ? convertedValue : default;

    /// <summary>
    /// Attempts to convert the value to an <see cref="long"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="long"/> if successful or the default</returns>
    public static long ToLong(this string value, long defaultValue) => long.TryParse(value, out long convertedValue) ? convertedValue : defaultValue;

    /// <summary>
    /// Attempts to convert the value to an <see cref="Nullable{long}"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="Nullable{long}"/> if successful or a null</returns>
    public static long? ToLongNullable(this string value) => long.TryParse(value, out long convertedValue) ? convertedValue : null;

    /// <summary>
    /// Attempts to convert the value to an <see cref="uint"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="uint"/> if successful or the default</returns>
    public static uint ToUInt(this string value) => uint.TryParse(value, out uint convertedValue) ? convertedValue : default;

    /// <summary>
    /// Attempts to convert the value to an <see cref="uint"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="uint"/> if successful or the default</returns>
    public static uint ToUInt(this string value, uint defaultValue) => uint.TryParse(value, out uint convertedValue) ? convertedValue : defaultValue;

    /// <summary>
    /// Attempts to convert the value to an <see cref="uint"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="uint"/> if successful or a null</returns>
    public static uint? ToUIntNullable(this string value) => uint.TryParse(value, out uint convertedValue) ? convertedValue : null;

    /// <summary>
    /// Attempts to convert the value to an <see cref="ushort"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="ushort"/> if successful or the default</returns>
    public static ushort ToUShort(this string value) => ushort.TryParse(value, out ushort convertedValue) ? convertedValue : default;

    /// <summary>
    /// Attempts to convert the value to an <see cref="ushort"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="ushort"/> if successful or the default</returns>
    public static ushort ToUShort(this string value, ushort defaultValue) => ushort.TryParse(value, out ushort convertedValue) ? convertedValue : defaultValue;

    /// <summary>
    /// Attempts to convert the value to an <see cref="ushort"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="ushort"/> if successful or a null</returns>
    public static ushort? ToUShortNullable(this string value) => ushort.TryParse(value, out ushort convertedValue) ? convertedValue : null;

    /// <summary>
    /// Attempts to convert the value to an <see cref="ulong"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="ulong"/> if successful or the default</returns>
    public static ulong ToULong(this string value) => ulong.TryParse(value, out ulong convertedValue) ? convertedValue : default;

    /// <summary>
    /// Attempts to convert the value to an <see cref="ulong"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="ulong"/> if successful or the default</returns>
    public static ulong ToULong(this string value, ulong defaultValue) => ulong.TryParse(value, out ulong convertedValue) ? convertedValue : defaultValue;

    /// <summary>
    /// Attempts to convert the value to an <see cref="ulong"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="ulong"/> if successful or a null</returns>
    public static ulong? ToULongNullable(this string value) => ulong.TryParse(value, out ulong convertedValue) ? convertedValue : null;

    /// <summary>
    /// Attempts to convert the value to an <see cref="float"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="float"/> if successful or the default</returns>
    public static float ToFloat(this string value) => float.TryParse(value, out float convertedValue) ? convertedValue : default;

    /// <summary>
    /// Attempts to convert the value to an <see cref="float"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="float"/> if successful or the default</returns>
    public static float ToFloat(this string value, float defaultValue) => float.TryParse(value, out float convertedValue) ? convertedValue : defaultValue;

    /// <summary>
    /// Attempts to convert the value to an <see cref="Nullable{float}"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="Nullable{float}"/> if successful or a null</returns>
    public static float? ToFloatNullable(this string value) => float.TryParse(value, out float convertedValue) ? convertedValue : null;

    /// <summary>
    /// Attempts to convert the value to an <see cref="decimal"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="decimal"/> if successful or the default</returns>
    public static decimal ToDecimal(this string value) => decimal.TryParse(value, out decimal convertedValue) ? convertedValue : default;

    /// <summary>
    /// Attempts to convert the value to an <see cref="decimal"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="decimal"/> if successful or the default</returns>
    public static decimal ToDecimal(this string value, decimal defaultValue) => decimal.TryParse(value, out decimal convertedValue) ? convertedValue : defaultValue;

    /// <summary>
    /// Attempts to convert the value to a nullable decimal/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as a nullable decimal if successful or a null</returns>
    public static decimal? ToDecimalNullable(this string value) => decimal.TryParse(value, out decimal convertedValue) ? convertedValue : null;

    /// <summary>
    /// Attempts to convert the value to an <see cref="double"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="double"/> if successful or the default</returns>
    public static double ToDouble(this string value) => double.TryParse(value, out double convertedValue) ? convertedValue : default;

    /// <summary>
    /// Attempts to convert the value to an <see cref="double"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="double"/> if successful or the default</returns>
    public static double ToDouble(this string value, double defaultValue) => double.TryParse(value, out double convertedValue) ? convertedValue : defaultValue;

    /// <summary>
    /// Attempts to convert the value to an <see cref="Nullable{Double}"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="Nullable{double}"/> if successful or a null</returns>
    public static double? ToDoubleNullable(this string value) => double.TryParse(value, out double convertedValue) ? convertedValue : null;

    /// <summary>
    /// Attempts to convert the value to an <see cref="DateTime"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="DateTime"/> if successful or the default</returns>
    public static DateTime ToDateTime(this string value) => DateTime.TryParse(value, out DateTime convertedValue) ? convertedValue : default;

    /// <summary>
    /// Attempts to convert the value to an <see cref="DateTime"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">The default value if the conversion fails</param>
    /// <returns>The value as an <see cref="DateTime"/> if successful or the default</returns>
    public static DateTime ToDateTime(this string value, DateTime defaultValue) => DateTime.TryParse(value, out DateTime convertedValue) ? convertedValue : defaultValue;

    public static DateOnly ToDateOnly(this string value) => DateOnly.TryParse(value, out DateOnly convertedValue) ? convertedValue : default;

    public static DateOnly ToDateOnly(this string value, DateOnly defaultValue) => DateOnly.TryParse(value, out DateOnly convertdValue) ? convertdValue : defaultValue;

    public static TimeOnly ToTimeOnly(this string value) => TimeOnly.TryParse(value, out TimeOnly convertedValue) ? convertedValue : default;

    public static TimeOnly ToTimeOnly(this string value, TimeOnly defaultValue) => TimeOnly.TryParse(value, out TimeOnly convertedValue) ? convertedValue : defaultValue;
    /// <summary>
    /// Attempts to convert the value to an <see cref="Nullable{DateTime}"/>
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as an <see cref="Nullable{DateTime}"/> if successful or a null</returns>
    public static DateTime? ToDateTimeNullable(this string value) => DateTime.TryParse(value, out DateTime convertedValue) ? convertedValue : null;

    /// <summary>
    /// Attempts to convert the value to a <see cref="Encoding.UTF8"/> <see cref="byte"/> array
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <returns>The value as a <see cref="Encoding.UTF8"/> <see cref="byte"/> array</returns>
    public static byte[] ToUTF8ByteArray(this string value) => Encoding.UTF8.GetBytes(value);

    public static bool ToBool(this string value) => bool.TryParse(value, out bool convertedValue) && convertedValue;

    /// <summary>
    /// Converts a <see cref="String"/> into camel case
    /// </summary>
    /// <param name="text">The <see cref="String"/> to convert.</param>
    /// <returns>The <see cref="String"/> with camel casing applied.</returns>
    public static string ToCamelCase(this string text) => Char.ToLowerInvariant(text[0]) + text.Substring(1);

    /// <summary>
    /// Converts a <see cref="String"/> into Proper casing.
    /// </summary>
    /// <param name="text">The <see cref="String"/> to convert.</param>
    /// <returns>The <see cref="String"/> with camel casing applied.</returns>
    public static string ToProperCase(this string text) => _textInfo.ToTitleCase(text);
    #endregion

    #region Randomiser Methods

    #endregion

    #region File Management
    /// <summary>
    /// Efficiently reads the file specified into a <see cref="StringBuilder"/> instance.
    /// </summary>
    /// <param name="path">The path to the file to be read.</param>
    /// <returns>A <see cref="Result{TResult, TException}"> of </see>/><see cref="StringBuilder"/> instance, or an <see cref="Exception"/>.</returns>
    /// <remarks>
    /// Note: This is a best practise high throughput solution. This shouldn't suffer memory leaks
    /// </remarks>
    public static Result<StringBuilder, Exception> ImportToStringBuilder(this string path)
    {
        StringBuilder stringBuilder = new();

        if (!File.Exists(path)) return new FileNotFoundException(path);

        try
        {
            // 64 KB buffer
            using FileStream fileStream = new(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 1024 * 64, useAsync: false);
            using StreamReader reader = new(fileStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, bufferSize: 1024 * 64);

            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                stringBuilder.AppendLine(line);
            }
        }
        catch (Exception ex)
        {
            return ex;
        }

        return stringBuilder;
    }
    #endregion

    public static Dictionary<string, string> ParseDynamicPath(this string value)
    {
        Dictionary<string, string> parsedText = [];

        // Get the wrapped text, complete with wrapper
        string wrappedText = RegexHelper.DynamicTextSquareBrackets.Match(value).Value;

        if (!string.IsNullOrEmpty(wrappedText))
        {
            parsedText[DynamicTextRepresentationConstants.SPECIAL_FOLDER] = wrappedText.Substring(1, wrappedText.Length);
        }

        return parsedText;
    }

    /// <summary>
    /// Parses the string for directories, as specified by either / // \ \\
    /// </summary>
    /// <param name="value">The string containing a path</param>
    /// <returns>An array containing the directory names or an empty array</returns>
    public static string[] SplitOnDirectorySeparators(this string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            if (value.Contains('/'))
            {
                if (value.Contains("//"))
                {
                    return value.Split("//");
                }
                return value.Split('/');
            }
            if (value.Contains(@"\"))
            {
                if (value.Contains(@"\\"))
                {
                    return value.Split(@"\\");
                }
                return value.Split(@"\");
            }
        }
        return [];
    }

    public static void DumpToFile(this string value, string path)
    {
        using StreamWriter streamWriter = new(path);

        streamWriter.Write(value);
        streamWriter.Flush();
        streamWriter.Close();
        streamWriter.Dispose();

    }

    public static async Task DumpToFileAsync(this string value, string path)
    {
        using StreamWriter streamWriter = new(path);

        await streamWriter.WriteAsync(value);
        await streamWriter.FlushAsync();
        streamWriter.Close();
        await streamWriter.DisposeAsync();
    }

    /// <summary>
    /// Splits a string, splitting on each new line.
    /// </summary>
    /// <param name="value">The string</param>
    /// <returns>An array of strings.</returns>
    public static string[] SplitOnNewLine(this string value) => [.. value.Split(["\r\n", "\r", "\n"], StringSplitOptions.RemoveEmptyEntries)];

    #region Switch Dictionaries
    private static Dictionary<string, Type> _cSharpTypeFromName = new()
    {
        ["string"] = typeof(string),
        ["int"] = typeof(int),
        ["int?"] = typeof(int?),
        ["short"] = typeof(short),
        ["short?"] = typeof(short?),
        ["long"] = typeof(long),
        ["long?"] = typeof(long?),
        ["decimal"] = typeof(decimal),
        ["decimal?"] = typeof(decimal?),
        ["DateTime"] = typeof(DateTime),
        ["DateTime?"] = typeof(DateTime?),
        ["DateOnly"] = typeof(DateOnly),
        ["DateOnly?"] = typeof(DateOnly?),
        ["DateTimeOffset"] = typeof(DateTimeOffset),
        ["DateTimeOffset?"] = typeof(DateTimeOffset?),
        ["bool"] = typeof(bool),
        ["bool?"] = typeof(bool?),
        ["Dictionary<string, string>"] = typeof(Dictionary<string, string>),
        ["Dictionary<int, string"] = typeof(Dictionary<int, string>),
        ["Dictionary<string, int>"] = typeof(Dictionary<string, int>)
    };
    #endregion
}
