using Pure.BO.Coders;
using Pure.Library.Extensions;
using System.Reflection;
using Entity = Pure.Dal.Coders.Toolbox.Entities;

namespace Pure.Coders.Service.Mappers;

public static class PropertySpecificationMapper
{
    public static PropertySpecification[] Map(PropertyInfo[] items)
        => [.. items.Select(item => Map(item))];

    public static Entity.PropertySpecification[] Map(PropertySpecification[] items)
        => [.. items.Select(item => Map(item))];

    public static PropertySpecification[] Map(Entity.PropertySpecification[] items)
        => [.. items.Select(item => Map(item))];

    public static Entity.PropertySpecification Map(PropertySpecification item)
    {
        item.GenerateCodeObjects();
        return new()
        {
            Id = string.IsNullOrEmpty(item.Id) ? Guid.NewGuid().ToString() : item.Id,
            ClassId = item.ClassId,
            Name = item.Name,
            Type = item.Type,
            IsNumeric = item.IsNumeric,
            IsCollection = item.IsCollection,
            IsDate = item.IsDate,
            PropertySpecificationCodeImplementations = [.. PropertySpecificationCodeImplementationMapper.Map(item.PropertySpecificationCodeImplementations!)]
        };
    }

    public static PropertySpecification Map(PropertyInfo item)
    {
        return new()
        {
            Name = item.Name,
            PropertyInfo = item,
            IsNumeric = item.IsNumeric(),
            IsDate = item.IsDate(),
            IsCollection = item.PropertyType.IsACollection(),
            Type = item.PropertyType.CSharpTypeMapping()
        };
    }

    public static PropertySpecification Map(Entity.PropertySpecification item)
        => new()
        {
            Id = item.Id,
            ClassId = item.ClassId,
            Name = item.Name,
            Type = item.Type,
            IsNumeric = item.IsNumeric,
            IsCollection = item.IsCollection,
            IsDate = item.IsDate
        };
}
