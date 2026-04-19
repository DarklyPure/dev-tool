using System.Collections;
using System.Reflection;
using System.Text;

namespace Pure.Library.Extensions;

/// <summary>
/// A set of extensions adding extensibility to the <see cref="Type"/>.
/// </summary>
public static class TypeExtensions
{
    #region Switch Dictionaries
    /// <summary>
    /// Maps the key .net <see cref="Type"/> to the "friendly" name.
    /// </summary>
    /// <remarks>
    /// For use with Generators.
    /// </remarks>
    private static Dictionary<Type, string> _cSharpTypeMapping = new()
    {
        [typeof(string)] = "string",
        [typeof(int)] = "int",
        [typeof(int?)] = "int?",
        [typeof(short)] = "short",
        [typeof(short?)] = "short?",
        [typeof(long)] = "long",
        [typeof(long)] = "long?",
        [typeof(decimal)] = "decimal",
        [typeof(decimal?)] = "decimal?",
        [typeof(DateTime)] = "DateTime",
        [typeof(DateTime?)] = "DateTime?",
        [typeof(DateOnly)] = "DateOnly",
        [typeof(DateOnly?)] = "DateOnly?",
        [typeof(DateTimeOffset)] = "DateTimeOffset",
        [typeof(DateTimeOffset?)] = "DateTimeOffset?",
        [typeof(bool)] = "bool",
        [typeof(bool?)] = "bool?",
        [typeof(Dictionary<string, string>)] = "Dictionary<string, string>",
        [typeof(byte[])] = "byte[]"
    };

    private static Dictionary<Type, string> _typescriptTypeMapping = new()
    {
        [typeof(string)] = "string",
        [typeof(int)] = "number",
        [typeof(int?)] = "number | null",
        [typeof(short)] = "number",
        [typeof(short?)] = "number | null",
        [typeof(long)] = "bigint",
        [typeof(long)] = "bigint | null",
        [typeof(decimal)] = "number",
        [typeof(decimal?)] = "number | null",
        [typeof(DateTime)] = "Date",
        [typeof(DateTime?)] = "Date | null",
        [typeof(DateOnly)] = "Date",
        [typeof(DateOnly?)] = "Date | null",
        [typeof(DateTimeOffset)] = "Date",
        [typeof(DateTimeOffset?)] = "Date | null",
        [typeof(bool)] = "boolean",
        [typeof(bool?)] = "boolean | null"
    };

    /// <summary>
    /// Maps the key .net <see cref="Type"/> to it's test data load.
    /// </summary>
    /// <remarks>
    /// For use with Generators.
    /// </remarks>
    private static readonly Dictionary<Type, string> _testVariableDataLoad = new()
    {
        [typeof(string)] = " = Guid.NewGuid().ToString()",
        [typeof(int)] = " = _random.Next(0,1000)",
        [typeof(int?)] = " = _random.Next(0,1000)",
        [typeof(bool)] = " = _random.Next(0,1) == 1",
        [typeof(byte[])] = " = Guid.NewGuid().ToByteArray()"
    };

    /// <summary>
    /// Routes the call to the appropriate Code generation method.
    /// </summary>
    private static readonly Dictionary<string, Func<Type, string>> _codeGeneratorInvocations = new()
    {
        ["C#-Builder"] = (Type type) => GenerateCSharpBuilderClass(type)
    };
    #endregion

    #region Analysers
    /// <summary>
    /// Returns the "friendly" C# name of the type passed.
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <returns>The "friendly name" or the name of the <see cref="Type"/> passed, if it's not listed.</returns>
    /// <remarks>
    /// Utilises the <see cref="_cSharpTypeMapping"/> dictionary.
    /// </remarks>
    public static string CSharpTypeMapping(this Type type)
    {
        try
        {
            return _cSharpTypeMapping[type];
        }
        catch (Exception)
        {
            // Check if is a list
            if (type.Name.Contains("List`1"))
            {
                // Parse on space comma first
                string[] parsedFullName = type.FullName!.Split(", ");

                // Further parse down on full stop
                string[] parsedNames = parsedFullName[0].Split(".");

                // The last element is the name
                return $"List<{parsedNames.Last()}>";
            }
        }
        return type.Name;
    }

    /// <summary>
    /// Returns the "friendly" Typescript name of the type passed.
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <returns>The "friendly name" or the name of the <see cref="Type"/> passed, if it's not listed.</returns>
    /// <remarks>
    /// Utilises the <see cref="_typescriptTypeMapping"/> dictionary.
    /// </remarks>
    public static string TypescriptTypeMapping(this Type type)
    {
        try
        {
            return _typescriptTypeMapping[type];
        }
        catch (Exception)
        {
            // Check if is a list
            if (type.Name.Contains("List`1"))
            {
                // Parse on space comma first
                string[] parsedFullName = type.FullName!.Split(", ");

                // Further parse down on full stop
                string[] parsedNames = parsedFullName[0].Split(".");

                // The last element is the name
                return $"List<{parsedNames.Last()}>";
            }
        }
        return type.Name;
    }

    /// <summary>
    /// Checks is an array of type T
    /// </summary>
    /// <typeparam name="T">The base type of the array</typeparam>
    /// <param name="type">The type being tested</param>
    /// <returns>Returns true if is of <see cref="Type"/></returns>
    public static bool IsArrayOf<T>(this Type type) => type == typeof(T[]);

    /// <summary>
    /// Checks is a List/IList of type T
    /// </summary>
    /// <typeparam name="T">The base type of the List/IList</typeparam>
    /// <param name="type">The type being tested</param>
    /// <returns>Returns true if is of <see cref="Type"/></returns>
    public static bool IsListOf<T>(this Type type)
    {
        if (type == typeof(List<T>))
        {
            return true;
        }
        if (type == typeof(IList<T>))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Specifies if interface type passed is implemented by the object being tested
    /// </summary>
    /// <param name="type">The type being tested</param>
    /// <param name="interfacetype">The interface type being tested for</param>
    /// <returns></returns>
    /// <example>
    /// list.GetType().ImplementsGenericInterace(typeof(IList<>)));
    /// list.GetType().ImplementsGenericInterace(typeof(IEnumerable<>)));
    /// </example>
    public static bool ImplementsGenericInterface(this Type type, Type interfacetype)
    {
        return type.GetTypeInfo()
        .ImplementedInterfaces
        .Any(x => x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == interfacetype);
    }

    /// <summary>
    /// Specifies if the <see cref="Type"/> is a collection <see cref="Type"/>.
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <returns>True if is a collection.</returns>
    public static bool IsACollection(this Type type) => !typeof(String).Equals(type) && typeof(IEnumerable).IsAssignableFrom(type);

    public static void MustDeriveFrom<T>(this Type[] types)
    {
        List<Type> invalidTypes = [.. types.Where(m => !typeof(T).IsAssignableFrom(m))];

        if (invalidTypes.Count != 0)
        {
            throw new ArgumentException($"Types must derive from {typeof(T).Name}, failing types: {string.Join(",", invalidTypes)}");
        }
    }

    /// <summary>
    /// Specifies if the <see cref="Type"/> is a numeric.
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <returns>True if the <see cref="Type"/> is a numeric.</returns>
    public static bool IsNumeric(this Type type) => type.GetProperties()
        .Any(f =>
        f.PropertyType == typeof(int) ||
        f.PropertyType == typeof(int?) ||
        f.PropertyType == typeof(long) ||
        f.PropertyType == typeof(long?) ||
        f.PropertyType == typeof(short) ||
        f.PropertyType == typeof(short?) ||
        f.PropertyType == typeof(Decimal) ||
        f.PropertyType == typeof(Decimal?) ||
        f.PropertyType == typeof(float) ||
        f.PropertyType == typeof(float?) ||
        f.PropertyType == typeof(double) ||
        f.PropertyType == typeof(double?));

    /// <summary>
    /// Specifies if the <see cref="Type"/> is a date, date/time or time.
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <returns>True if the <see cref="Type"/> is a date, date/time or time.</returns>
    public static bool ContainsDate(this Type type) => type.GetProperties()
        .Any(f =>
        f.PropertyType == typeof(DateTime) ||
        f.PropertyType == typeof(DateTime?) ||
        f.PropertyType == typeof(DateTimeOffset) ||
        f.PropertyType == typeof(DateTimeOffset?) ||
        f.PropertyType == typeof(DateOnly) ||
        f.PropertyType == typeof(DateOnly?));
    #endregion

    #region Implementations

    /// <summary>
    /// Gets the base type of the IEnumerable object
    /// </summary>
    /// <param name="enumerable">The IEnumerable to be tested</param>
    /// <returns>Returns the base type</returns>
    public static Type? GetEnumerableBaseType(this IEnumerable enumerable)
    {
        // Check if the list has a
        Type[] interfaces = enumerable.GetType().GetInterfaces();
        Type? elementType = interfaces.Where(f => f.IsGenericType && f.GetGenericTypeDefinition() == typeof(IEnumerable<>)).Select(s => s.GetGenericArguments()[0]).FirstOrDefault();
        //peek at the first element in the list if you couldn't determine the element type
        if (elementType == null || elementType == typeof(object))
        {
            object? firstElement = enumerable.Cast<object>().FirstOrDefault();
            if (firstElement != null)
            {
                elementType = firstElement.GetType();
            }
        }
        return elementType;
    }

    /// <summary>
    /// Gets the appropropriate test data load.
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <returns>A string representing a test data load.</returns>
    /// <example>
    ///  = _random.Next(0,1000)
    /// </example>
    /// <remarks>
    /// Safely uses <see cref="_testVariableDataLoad"/>.
    /// </remarks>
    public static string GetTestDataDataLoad(this Type type)
    {
        try
        {
            return _testVariableDataLoad[type];
        }
        catch (Exception) { return string.Empty; }
    }
    #endregion

    #region Code Generators
    /// <summary>
    /// Generates the start of a C# class
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <param name="modifier">Optional - The modifier.</param>
    /// <param name="namePrefix">Optional - The name prefix.</param>
    /// <param name="nameSuffix">Optional - The name suffix.</param>
    /// <returns>A C# class start</returns>
    /// <example>
    /// public class ThisIsTheClass
    /// {
    /// </example>
    private static string GenerateCSharpClassStart(Type type, string? modifier = "public", string? namePrefix = null, string? nameSuffix = null)
    {
        StringBuilder builder = new();

        builder
            .Append(modifier)
            .Append(" class ")
            .Append(!string.IsNullOrEmpty(namePrefix) ? namePrefix : string.Empty)
            .Append(type.Name)
            .Append(!string.IsNullOrEmpty(nameSuffix) ? nameSuffix : string.Empty)
            .AppendLine()
            .Append('{')
            .AppendLine();

        return builder.ToString();
    }

    /// <summary>
    /// Generates a C# based Builder class.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static string GenerateCSharpBuilderClass(Type type)
    {
        StringBuilder builder = new();

        if (!string.IsNullOrEmpty(type.Namespace))
        {
            builder
                .Append("namespace ")
                .Append(type.Namespace)
                .Append(".Tests;");
        }

        builder
            .AppendLine()
            .Append("/// <summary>")
            .AppendLine()
            .Append("/// ")
            .Append("Builder for ")
            .Append(type.Name)
            .Append(" objects.")
            .AppendLine()
            .Append("/// </summary>")
            .AppendLine()
            .Append(GenerateCSharpClassStart(type, "public", null, "Builder"));

        // Check for static variables to add
        if (type.IsNumeric() || type.ContainsDate())
        {
            builder
                .Append('\t')
                .Append("private static Random _random = new();")
                .AppendLine();

            if (type.ContainsDate())
            {
                builder
                    .Append('\t')
                    .Append("private static DateTime _baseData = DateTime.Now.AddDays(_random.Next(0,1000));")
                    .AppendLine();
            }

            builder
                .AppendLine();
        }

        // Create the variables
        builder
            .Append(GenerateCSharpVariables(type, true));

        builder
            .Append('\t')
            .Append("private ")
            .Append(type.Name)
            .Append('?')
            .Append(" _object;")
            .AppendLine()
            .AppendLine();

        builder
            .Append(GenerateCSharpBuildMethod(type))
            .AppendLine()
            .Append(GenerateCSharpBuilderWithMethod(type))
            .Append(GenerateCSharpClosingCurlyBracket());

        return builder.ToString();
    }

    /// <summary>
    /// Generates C# variables.
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <param name="includeTestData">Specifies whether to include test data.</param>
    /// <returns></returns>
    private static string GenerateCSharpVariables(Type type, bool includeTestData = false)
    {
        PropertyInfo[] properties = [.. type.GetProperties().Where(f => f.CanWrite)];
        StringBuilder builder = new();

        int i = 0;
        while (i < properties.Length)
        {
            PropertyInfo propertyInfo = properties[i++];
            builder
                .Append('\t')
                .Append(propertyInfo.ToVariable($"C#-Builder-Variable"))
                .AppendLine();
        }
        builder
            .AppendLine();
        return builder.ToString();
    }

    /// <summary>
    /// Generates a C# Builder method.
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <returns>A string representing a C# Builder method.</returns>
    /// <example>
    /// public Object Build()
    /// {
    ///     return _object ??= new()
    ///     {
    ///         StringValue = _stringValue
    ///     };
    /// }
    /// </example>
    private static string GenerateCSharpBuildMethod(Type type)
    {
        PropertyInfo[] properties = [.. type.GetProperties().Where(f => f.CanWrite)];
        StringBuilder builder = new();

        builder
            .Append('\t')
            .Append("public ")
            .Append(type.Name)
            .Append(' ')
            .Append("Build()")
            .AppendLine()
            .Append('\t')
            .Append('{')
            .AppendLine()
            .Append("\t\t")
            .Append("return _object ??= new()")
            .AppendLine()
            .Append("\t\t")
            .Append('{')
            .AppendLine();

        int i = 0;
        while (i < properties.Length)
        {
            PropertyInfo propertyInfo = properties[i++];

            builder
                .Append("\t\t\t")
                .Append(propertyInfo.ToOneToOnePropertySet("C#-OneToOnePropertySet"))
                .Append(i < properties.Length ? ',' : string.Empty);

            if (i < properties.Length)
            {
                builder
                    .AppendLine();
            }
        }

        builder
            .AppendLine()
            .Append("\t\t")
            .Append(GenerateCSharpClosingCurlyBracket(true))
            .Append('\t')
            .Append(GenerateCSharpClosingCurlyBracket());

        return builder.ToString();
    }

    /// <summary>
    /// Generates a C# builder With method.
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <returns>A string representing a C# With builder method</returns>
    /// <example>
    /// public ObjectBuilder WithString(string value)
    /// {
    ///     _stringValue = value;
    ///     return this;
    /// }
    /// </example>
    private static string GenerateCSharpBuilderWithMethod(Type type)
    {
        PropertyInfo[] properties = [.. type.GetProperties().Where(f => f.CanWrite)];
        StringBuilder builder = new();

        int i = 0;
        while (i < properties.Length)
        {
            PropertyInfo propertyInfo = properties[i++];

            builder
            .Append('\t')
            .Append("public ")
            .Append(' ')
            .Append(type.Name)
            .Append("Builder")
            .Append(' ')
            .Append("With")
            .Append(propertyInfo.Name)
            .Append('(')
            .Append(propertyInfo.PropertyType.CSharpTypeMapping())
            .Append(" value)")
            .AppendLine()
            .Append('\t')
            .Append('{')
            .AppendLine()
            .Append("\t\t")
            .Append("_")
            .Append(propertyInfo.Name.ToCamelCase())
            .Append(" = value;")
            .AppendLine()
            .Append("\t\t")
            .Append("return this;")
            .AppendLine()
            .Append('\t')
            .Append(GenerateCSharpClosingCurlyBracket())
            .AppendLine();
        }
        return builder.ToString();
    }

    /// <summary>
    /// Generates a C# closing curly bracket.
    /// </summary>
    /// <param name="addSemiColon">Specifies if a semi-colon is to be added.</param>
    /// <returns>A string representing a C# closing curly bracket</returns>
    /// <example>
    /// };
    /// </example>
    private static string GenerateCSharpClosingCurlyBracket(bool addSemiColon = false)
    {
        StringBuilder builder = new();

        builder
            .Append('}')
            .Append(addSemiColon ? ';' : string.Empty)
            .AppendLine();

        return builder.ToString();
    }
    #endregion
}
