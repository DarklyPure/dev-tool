using Pure.Library.Extensions;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Pure.Library.Helpers;

/// <summary>
/// Performs automatic conversions whereby a destination data type differs 
/// from the input type but the underlying data types are actually the same.
/// </summary>
public class AutoConverter
{
    #region Statics
    /// <summary>
    /// Converts the string value passed, to the <see cref="Type"/> as specified by T
    /// </summary>
    /// <typeparam name="T">The required <see cref="Type"/></typeparam>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">Optional - A default value to return if the conversion fails</param>
    /// <returns>The passed value in typed accordingly, or the default value if the conversion failed</returns>
    public static T? ToType<T>(string value, object? defaultValue = null) where T : new()
    {
        AutoConverter autoConverter = new();

        if (defaultValue != null)
        {
            return autoConverter.TryConvert<T>(value, (T)defaultValue);
        }
        return autoConverter.TryConvert<T>(value);
    }

    /// <summary>
    /// Converts the string value passed, to the <see cref="Type"/> as specified by T
    /// </summary>
    /// <param name="type">The required <see cref="Type"/></param>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">Optional - A default value to return if the conversion fails</param>
    /// <returns>The passed value in typed accordingly, or the default value if the conversion failed</returns>
    public static object? ToTypedObject(Type type, string value, object? defaultValue = null)
    {
        AutoConverter autoConverter = new();

        if (defaultValue != null)
        {
            return autoConverter.TryConvert(type, value);
        }
        return autoConverter.TryConvert(type, value);
    }

    /// <summary>
    /// Converts the value of the  <see cref="JsonNode"/> passed, to the <see cref="Type"/> as specified
    /// </summary>
    /// <param name="jsonNode">The <see cref="JsonNode"/> containing your data</param>
    /// <returns>The</returns>
    public static object? ToTypedObject(JsonNode jsonNode)
    {
        AutoConverter autoConverter = new();

        return autoConverter.TryConvert(jsonNode);
    }
    #endregion

    #region Constructors
    /// <summary>
    /// C'Tor loads up an <see cref="IDictionary{TKey, TValue}"/> instance
    /// which acts as a switch for use with conversions.
    /// </summary>
    public AutoConverter()
    {
        // Load up the strongly typed converters
        _strictlyTypedConverters = new()
        {
            [typeof(int)] = (string value) => value.ToInt(),
            [typeof(int?)] = (string value) => value.ToIntNullable(),
            [typeof(short)] = (string value) => value.ToShort(),
            [typeof(short?)] = (string value) => value.ToShortNullable(),
            [typeof(long)] = (string value) => value.ToLong(),
            [typeof(long?)] = (string value) => value.ToLongNullable(),
            [typeof(decimal)] = (string value) => value.ToDecimal(),
            [typeof(decimal?)] = (string value) => value.ToDecimalNullable(),
            [typeof(double)] = (string value) => value.ToDouble(),
            [typeof(double?)] = (string value) => value.ToDoubleNullable(),
            [typeof(ushort)] = (string value) => value.ToUShort(),
            [typeof(uint)] = (string value) => value.ToUInt(),
            [typeof(ulong)] = (string value) => value.ToULong(),
            [typeof(float)] = (string value) => value.ToFloat(),
            [typeof(float?)] = (string value) => value.ToFloatNullable(),
            [typeof(DateTime)] = (string value) => value.ToDateTime(),
            [typeof(DateTime?)] = (string value) => value.ToDateTimeNullable()
        };

        // Load up the more loosely typed converters
        _looselyTypedConverters = new()
        {
            [typeof(int)] = (string value, object defaultValue) => value.ToInt((int)defaultValue),
            [typeof(short)] = (string value, object defaultValue) => value.ToShort((short)defaultValue),
            [typeof(long)] = (string value, object defaultValue) => value.ToLong((long)defaultValue),
            [typeof(decimal)] = (string value, object defaultValue) => value.ToDecimal((decimal)defaultValue),
            [typeof(double)] = (string value, object defaultValue) => value.ToDouble((double)defaultValue),
            [typeof(ushort)] = (string value, object defaultValue) => value.ToUShort((ushort)defaultValue),
            [typeof(uint)] = (string value, object defaultValue) => value.ToUInt((uint)defaultValue),
            [typeof(ulong)] = (string value, object defaultValue) => value.ToULong((ulong)defaultValue),
            [typeof(float)] = (string value, object defaultValue) => value.ToFloat((float)defaultValue),
            [typeof(DateTime)] = (string value, object defaultValue) => value.ToDateTime((DateTime)defaultValue),
        };

        // Load up the JsonNode converters
        _strictlyTypedJsonConverters = new()
        {
            [JsonValueKind.Number] = (JsonNode jsonNode) => jsonNode.GetValue<int>(),
            [JsonValueKind.String] = (JsonNode jsonNode) => jsonNode.GetValue<string>(),
            [JsonValueKind.True] = (JsonNode jsonNode) => jsonNode.GetValue<bool>(),
            [JsonValueKind.False] = (JsonNode jsonNode) => jsonNode.GetValue<bool>(),
            [JsonValueKind.Array] = (JsonNode jsonNode) => jsonNode.GetValue<string[]>()
        };
    }
    #endregion

    #region Local Variables
    /// <summary>
    /// <see cref="Type"/> converter <see cref="Dictionary{TKey, TValue}"/>
    /// </summary>
    /// <remarks>
    /// If the conversion fails, this will return the default for the <see cref="Type"/> T, 
    /// or a null if the requested type is nullable.
    /// </remarks>
    private readonly Dictionary<Type, Func<string, object?>> _strictlyTypedConverters;

    /// <summary>
    /// <see cref="Type"/> converter <see cref="Dictionary{TKey, TValue}"/>
    /// </summary>
    /// <remarks>
    /// If the conversion fails, this will return the default value passed
    /// </remarks>
    private readonly Dictionary<Type, Func<string, object, object>> _looselyTypedConverters;

    private readonly Dictionary<JsonValueKind, Func<JsonNode, object>> _strictlyTypedJsonConverters;
    #endregion

    #region Helper Methods
    /// <summary>
    /// Attempts to convert the value to the type specified.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> required</typeparam>
    /// <param name="value">The value</param>
    /// <returns>The data converted to <see cref="Type"/> or the <see cref="Type"/> default</returns>
    protected T? TryConvert<T>(string value) => (T?)_strictlyTypedConverters[typeof(T)].Invoke(value);
    /// <summary>
    /// Attempts to convert the value to the type spcified. If it fails sets the default value.
    /// </summary>
    /// <typeparam name="T">The required <see cref="Type"/>.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="defaultValue">The default value for if it fails.</param>
    /// <returns>The converted data.</returns>
    protected T? TryConvert<T>(string value, T defaultValue) => (T?)_looselyTypedConverters[typeof(T)].Invoke(value, defaultValue!);
    /// <summary>
    /// Attempts to convert the value to the type specified.
    /// </summary>
    /// <param name="type">The required <see cref="Type"/>.</param>
    /// <param name="value">The value.</param>
    /// <returns>The converted data.</returns>
    protected object? TryConvert(Type type, string value) => _strictlyTypedConverters[type].Invoke(value);
    /// <summary>
    /// Attempts to convert the value to the type specified.
    /// </summary>
    /// <param name="type">The require <see cref="Type"/>.</param>
    /// <param name="value">The value.</param>
    /// <param name="defaultValue">The default value for if it fails.</param>
    /// <returns>The converted data.</returns>
    protected object? TryConvert(Type type, string value, object defaultValue) => _looselyTypedConverters[type].Invoke(value, defaultValue);
    /// <summary>
    /// Attempts to convert the value to the type specified.
    /// </summary>
    /// <param name="jsonNode">A <see cref="JsonNode"/>.</param>
    /// <returns>The converted data.</returns>
    protected object? TryConvert(JsonNode jsonNode) => _strictlyTypedJsonConverters[jsonNode.GetValueKind()](jsonNode);
    #endregion
}
