using Pure.Library.Helpers;
using System.Reflection;
using System.Text;

namespace Pure.Library.Extensions;

public static class PropertyInfoExtensions
{
    #region Switch Dictionaries
    private static Dictionary<string, Func<PropertyInfo, string>> _codeGenerators = new()
    {
        [$"{CodingLanguageNames.CSharp}-{CodeObjectNames.BuilderVariable}"] = (PropertyInfo propertyInfo) => CSharpGenerateVariable(propertyInfo, true),
        [$"{CodingLanguageNames.CSharp}-{CodeObjectNames.OneToOnePropertySet}"] = (PropertyInfo propertyInfo) => CSharpOneToOnePropertySet(propertyInfo),
        [$"{CodingLanguageNames.Typescript}-{CodeObjectNames.OneToOnePropertySet}"] = (PropertyInfo propertyInfo) => TypescriptOneToOnePropertySet(propertyInfo),
        [$"{CodingLanguageNames.Typescript}-{CodeObjectNames.Variable}"] = (PropertyInfo propertyInfo) => TypescriptGenerateVariable(propertyInfo)
    };
    #endregion

    #region Analysers
    /// <summary>
    /// Specifies if the property type is that of a numeric.
    /// </summary>
    /// <param name="instance">The <see cref="PropertyInfo"/> instance.</param>
    /// <returns>True if is a numeric, false if not.</returns>
    public static bool IsNumeric(this PropertyInfo instance)
        => instance.PropertyType == typeof(int) ||
        instance.PropertyType == typeof(int?) ||
        instance.PropertyType == typeof(long) ||
        instance.PropertyType == typeof(long?) ||
        instance.PropertyType == typeof(short) ||
        instance.PropertyType == typeof(short?) ||
        instance.PropertyType == typeof(Decimal) ||
        instance.PropertyType == typeof(Decimal?) ||
        instance.PropertyType == typeof(float) ||
        instance.PropertyType == typeof(float?) ||
        instance.PropertyType == typeof(double) ||
        instance.PropertyType == typeof(double?);

    /// <summary>
    /// Specifies if the property type is that of a <see cref="DateOnly"/>, 
    /// <see cref="TimeOnly"/>, or <see cref="DateTime"/>
    /// </summary>
    /// <param name="instance">The <see cref="PropertyInfo"/> instance.</param>
    /// <returns>True if is a Date, DateTime or Time.</returns>
    public static bool IsDate(this PropertyInfo instance)
        => instance.PropertyType == typeof(DateTime) ||
        instance.PropertyType == typeof(DateTime?) ||
        instance.PropertyType == typeof(DateTimeOffset) ||
        instance.PropertyType == typeof(DateTimeOffset?) ||
        instance.PropertyType == typeof(DateOnly) ||
        instance.PropertyType == typeof(DateOnly?);
    #endregion

    #region Actions
    /// <summary>
    /// Attempts to set the value of the extended PropertyInfo instance
    /// </summary>
    /// <param name="propertyInfo">The extended object</param>
    /// <param name="value">The value to set</param>
    /// <returns>True if successful, false if not</returns>
    public static bool TrySetValue(this PropertyInfo propertyInfo, object instance, object? value)
    {
        try
        {
            // Attempt to set with value passed as is
            propertyInfo.SetValue(instance, value);
        }
        catch (Exception)
        {
            // Attempt to automatically convert to type
            object? convertedValue = typeof(AutoConverter).GetMethod("ToType")!.MakeGenericMethod(propertyInfo.PropertyType).Invoke(null, [value, null]);

            try
            {
                // Attempt to set with converted value
                propertyInfo.SetValue(instance, convertedValue);
            }
            catch (Exception)
            {
                return false;
            }
        }
        return true;
    }
    #endregion

    #region Filters
    /// <summary>
    /// Gets all Read Write properties
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/></typeparam>
    /// <param name="instance">The instance</param>
    /// <returns>An array of read/write capable properties</returns>
    public static PropertyInfo[] AllReadWriteProperties<T>(this T instance) where T : class => [.. instance.GetType().GetProperties().Where(f => f.CanWrite && f.CanRead)];
    #endregion

    #region Generators
    /// <summary>
    /// Generates a variable.
    /// </summary>
    /// <param name="propertyInfo">The <see cref="PropertyInfo"/>.</param>
    /// <param name="type">The type required.</param>
    /// <returns>A string representing a variable.</returns>
    public static string ToVariable(this PropertyInfo propertyInfo, string type) => _codeGenerators[type].Invoke(propertyInfo);

    /// <summary>
    /// Generates a one to one property set.
    /// </summary>
    /// <param name="propertyInfo">The <see cref="PropertyInfo"/>.</param>
    /// <param name="type">The type.</param>
    /// <returns>A string representing a one to one property set.</returns>
    /// <example>
    /// 
    /// </example>
    public static string ToOneToOnePropertySet(this PropertyInfo propertyInfo, string type) => _codeGenerators[type].Invoke(propertyInfo);

    /// <summary>
    /// Generates a C# one to one property set
    /// </summary>
    /// <param name="propertyInfo">The <see cref="PropertyInfo"/>.</param>
    /// <returns>A string representing a one to one property set.</returns>
    /// <example>
    /// TestValue = _testValue
    /// </example>
    private static string CSharpOneToOnePropertySet(PropertyInfo propertyInfo)
    {
        StringBuilder builder = new();

        builder
            .Append(propertyInfo.Name)
            .Append(" = _")
            .Append(propertyInfo.Name.ToCamelCase());

        return builder.ToString();
    }

    /// <summary>
    /// Generates a Typescript one to one property set
    /// </summary>
    /// <param name="propertyInfo">The <see cref="PropertyInfo"/>.</param>
    /// <returns>A string representing a one to one property set.</returns>
    /// <example>
    /// testValue = _testValue
    /// </example>
    /// <remarks>
    /// Defaults to camel case property names.
    /// </remarks>
    private static string TypescriptOneToOnePropertySet(PropertyInfo propertyInfo)
    {
        StringBuilder builder = new();

        builder
            .Append(propertyInfo.Name.ToCamelCase())
            .Append(" = _")
            .Append(propertyInfo.Name.ToCamelCase());

        return builder.ToString();
    }

    /// <summary>
    /// Generates a C# variable.
    /// </summary>
    /// <param name="propertyInfo">The <see cref="PropertyInfo"/>.</param>
    /// <param name="includeTestLoad">Specifies whether to include a test data load.</param>
    /// <returns>A string representing a C# variable</returns>
    /// <example>
    /// private string _stringValue = Guid.NewGuid().ToString();
    /// </example>
    /// <remarks>
    /// Utilises <see cref="_codeGenerators"/>.
    /// </remarks>
    private static string CSharpGenerateVariable(PropertyInfo propertyInfo, bool includeTestLoad = false)
    {
        StringBuilder builder = new();

        builder
            .Append("private ")
            .Append(propertyInfo.PropertyType.CSharpTypeMapping())
            .Append(' ')
            .Append('_')
            .Append(propertyInfo.Name.ToCamelCase());

        if (includeTestLoad)
        {
            builder
                .Append(propertyInfo.PropertyType.GetTestDataDataLoad());
        }
        builder
            .Append(';');

        return builder.ToString();
    }

    /// <summary>
    /// Generates a Typescript variable.
    /// </summary>
    /// <param name="propertyInfo">The <see cref="PropertyInfo"/>.</param>
    /// <returns>A string representing a Typescript variable</returns>
    /// <example>
    /// private string _stringValue;
    /// </example>
    /// <remarks>
    /// Utilises <see cref="_codeGenerators"/>.
    /// </remarks>
    private static string TypescriptGenerateVariable(PropertyInfo propertyInfo)
    {
        StringBuilder builder = new();

        builder
            .Append("private ")
            .Append(propertyInfo.PropertyType.TypescriptTypeMapping())
            .Append(' ')
            .Append('_')
            .Append(propertyInfo.Name.ToCamelCase());

        return builder.ToString();
    }
    #endregion
}
