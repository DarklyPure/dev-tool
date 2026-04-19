using Pure.BO.Coders;
using Pure.Library.Extensions;
using Entity = Pure.Dal.Coders.Toolbox.Entities;

namespace Pure.Coders.Service.Mappers;

public static class PropertySpecificationCodeImplementationMapper
{
    public static Entity.PropertySpecificationCodeImplementation[] Map(PropertySpecificationCodeImplementation[] items)
        => [.. items.Select(item => Map(item))];

    public static PropertySpecificationCodeImplementation[] Map(Entity.PropertySpecificationCodeImplementation[] items)
        => [.. items.Select(item => Map(item))];

    public static Entity.PropertySpecificationCodeImplementation Map(PropertySpecificationCodeImplementation item)
        => new()
        {
            Id = string.IsNullOrEmpty(item.Id) ? Guid.NewGuid().ToString() : item.Id,
            Language = item.Language,
            ImplementationType = item.ImplementationType,
            Code = string.IsNullOrEmpty(item.Code) ? null : item.Code!.ToUTF8ByteArray(),
            Lock = item.Lock
        };

    public static PropertySpecificationCodeImplementation Map(Entity.PropertySpecificationCodeImplementation item)
        => new()
        {
            Id = string.IsNullOrEmpty(item.Id) ? Guid.NewGuid().ToString() : item.Id,
            Language = item.Language,
            ImplementationType = item.ImplementationType,
            Code = item.Code != null ? item.Code!.ConvertToString() : null,
            Lock = item.Lock
        };
}
