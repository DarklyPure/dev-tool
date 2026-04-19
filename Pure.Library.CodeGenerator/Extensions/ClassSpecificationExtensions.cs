using Pure.BO.Coders;
using System.Text;

namespace Pure.Library.CodeGenerator.Extensions;

public static class ClassSpecificationExtensions
{
    public static string ToClassBuilder(this ClassSpecification instance)
    {
        StringBuilder builder = new();

        builder
            .Append("namespace")
            .Append(instance.AppearsInNamespace)
            .AppendLine()
            .Append("/// <summary>")
            .AppendLine()
            .Append("/// ")
            .Append("Builder for ")
            .Append(instance.Name)
            .Append(" objects.")
            .AppendLine()
            .Append("/// </summary>")
            .AppendLine()
            .Append("public ")
            .Append(instance.Name)
            .Append("Builder")
            .AppendLine()
            .Append('{')
            .AppendLine();

        if (instance.PropertySpecifications.Any(f => f.IsNumeric || f.IsDate))
        {
            builder
                .Append('\t')
                .Append("private static Random _random = new();")
                .AppendLine();

            if (instance.PropertySpecifications.Any(f => f.IsDate))
            {
                builder
                    .Append('\t')
                    .Append("private static DateTime _baseData = DateTime.Now.AddDays(_random.Next(0,1000));")
                    .AppendLine();
            }

            builder.AppendLine();
        }

        // Create the variables
        int i = 0;
        while (i < instance.PropertySpecifications?.Length)
        {

        }

        return builder.ToString();
    }

}
