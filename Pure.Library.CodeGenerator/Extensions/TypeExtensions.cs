using Pure.Library.Extensions;
using System.Reflection;
using System.Text;

namespace Pure.Library.CodeGenerator.Extensions;

/// <summary>
/// 
/// </summary>
public static class TypeExtensions
{


    #region Implementations
    public static string GenerateCode(this Type type, string codeFlavour, string codeObject)
    {
        try
        {
            string key = $"{codeFlavour}-{codeObject}";
            return _codeGeneratorInvocations[key].Invoke(type);
        }
        catch (Exception) { return string.Empty; }
    }
    public static string GetTestDataDataLoad(this Type type)
    {
        try
        {
            return _testVariableDataLoad[type];
        }
        catch (Exception) { return string.Empty; }
    }
    /// <summary>
    /// Safely gets the namespace if available, and empty string if not.
    /// </summary>
    /// <param name="type">The <see cref="Type"/>.</param>
    /// <returns>The namespace or an empty string.</returns>
    public static string GetNamespaceSafe(this Type type)
        => string.IsNullOrEmpty(type.Namespace) ? string.Empty : type.Namespace;
    #endregion

    #region Helpers
    /// <summary>
    /// Derives the root namespace, by picking the shortest namespace in the collection.
    /// </summary>
    /// <param name="types">A <see cref="Type"/> collection of classes.</param>
    /// <returns>A string.</returns>
    public static string DeriveRootNamespace(this Type[] types)
    {
        string[] namespaces = [.. types.Select(x => x.Namespace!).Distinct()];
        int minLength = namespaces.Min(x => x.Length);

        return namespaces.FirstOrDefault(x => x.Length == minLength)!;
    }
    #endregion

    #region Switch Dictionaries
    private static readonly Dictionary<string, Func<Type, string>> _codeGeneratorInvocations = new()
    {
        ["C#-Builder"] = (Type type) => GenerateCSharpBuilderClass(type)
    };
    private static readonly Dictionary<Type, string> _testVariableDataLoad = new()
    {
        [typeof(string)] = " = Guid.NewGuid().ToString()",
        [typeof(int)] = " = _random.Next(0,1000)",
        [typeof(int?)] = " = _random.Next(0,1000)",
        [typeof(bool)] = " = _random.Next(0,1) == 1",
        [typeof(byte[])] = " = Guid.NewGuid().ToByteArray()"
    };
    #endregion

    #region C# Helpers
    private static string GenerateCSharpBuilderClass(Type type)
    {
        StringBuilder builder = new();

        builder
            .Append(GenerateCSharpNamespace($"{type.Namespace}.Tests"))
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
    private static string GenerateCSharpClosingCurlyBracket(bool addSemiColon = false)
    {
        StringBuilder builder = new();

        builder
            .Append('}')
            .Append(addSemiColon ? ';' : string.Empty)
            .AppendLine();

        return builder.ToString();
    }
    private static string GenerateCSharpBOComparatorTest(Type type)
    {
        StringBuilder builder = new();

        builder
            .Append("[TestClass]")
            .Append(GenerateCSharpClassStart(type, "public", null, "Tests"))
            .AppendLine()
            .Append('{')
            .AppendLine()
            .Append('\t')
            .Append("[TestMethod]")
            .AppendLine()
            .Append('\t')
            .Append("public void ")
            .Append(type.Name)
            .Append("_Populated_Serialisation_AreEqual()")
            .AppendLine()
            .Append('\t')
            .Append('{')
            .AppendLine()
            .Append('\t')
            .Append("// Arrange")
            .AppendLine()
            .Append(type.Name)
            .Append(" sut = new ")
            .Append(type.Name)
            .Append("Builder().Build();")
            .AppendLine(); // TODO: Start Here


        return builder.ToString();
    }
    private static string GenerateCSharpNamespace(string nspace)
    {
        StringBuilder builder = new();

        builder
            .Append("namespace ")
            .Append(nspace)
            .Append(';')
            .AppendLine();

        return builder.ToString();
    }
    #endregion

    #region Typescript Helpers

    #endregion
}
