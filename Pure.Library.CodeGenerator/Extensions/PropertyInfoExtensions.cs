using Pure.Library.Extensions;
using System.Reflection;
using System.Text;

namespace Pure.Library.CodeGenerator.Extensions;

/// <summary>
/// Extensions on the <see cref="PropertyInfo"/> object.
/// </summary>
public static class PropertyInfoExtensions
{
    #region Switch Dictionaries
    private static Dictionary<string, Func<PropertyInfo, string>> _codeGenerators = new()
    {
        ["C#-Builder-Variable"] = (PropertyInfo propertyInfo) => CSharpGenerateVariable(propertyInfo, true),
        ["C#-OneToOnePropertySet"] = (PropertyInfo propertyInfo) => CSharpOneToOnePropertySet(propertyInfo)
    };
    #endregion

    #region Generic
    public static string ToVariable(this PropertyInfo propertyInfo, string type) => _codeGenerators[type].Invoke(propertyInfo);
    public static string ToOneToOnePropertySet(this PropertyInfo propertyInfo, string type) => _codeGenerators[type].Invoke(propertyInfo);

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

    #region C# Implementations
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
    private static string CSharpOneToOnePropertySet(PropertyInfo propertyInfo)
    {
        StringBuilder builder = new();

        builder
            .Append(propertyInfo.Name)
            .Append(" = _")
            .Append(propertyInfo.Name.ToCamelCase());

        return builder.ToString();
    }
    #endregion

    #region Typescript Implementations
    private static string TypescriptGenerateVariable(PropertyInfo propertyInfo)
    {
        StringBuilder builder = new();

        builder
            .Append("private _")
            .Append(propertyInfo.Name.ToCamelCase())
            .Append(": ");
        // .Append(propertyInfo.PropertyType.)


        return builder.ToString();
    }
    #endregion
}