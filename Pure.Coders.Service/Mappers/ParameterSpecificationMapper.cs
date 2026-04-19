using Pure.BO.Coders;
using Pure.Library.Extensions;
using System.Reflection;
using Entity = Pure.Dal.Coders.Toolbox.Entities;

namespace Pure.Coders.Service.Mappers;

public static class ParameterSpecificationMapper
{
    public static ParameterSpecification[] Map(ParameterInfo[] items)
        => [.. items.Select(item => Map(item))];

    public static Entity.ParameterSpecification[] Map(ParameterSpecification[] items)
        => [.. items.Select(item => Map(item))];

    public static ParameterSpecification[] Map(Entity.ParameterSpecification[] items)
        => [.. items.Select(item => Map(item))];

    public static ParameterSpecification Map(ParameterInfo item)
    {
        return new()
        {
            Name = item.Name ?? "_",
            Type = item.ParameterType.CSharpTypeMapping(),
            ByRef = item.ParameterType.IsByRef
        };
    }

    public static Entity.ParameterSpecification Map(ParameterSpecification item)
        => new()
        {
            Id = string.IsNullOrEmpty(item.Id) ? Guid.NewGuid().ToString() : item.Id,
            MethodId = item.MethodId,
            Name = item.Name,
            Type = item.Type,
            ByRef = item.ByRef
        };

    public static ParameterSpecification Map(Entity.ParameterSpecification item)
    => new()
    {
        Id = item.Id,
        MethodId = item.MethodId,
        Name = item.Name,
        Type = item.Type,
        ByRef = item.ByRef
    };
}
