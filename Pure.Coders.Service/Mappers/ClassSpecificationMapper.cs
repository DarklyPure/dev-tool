using Pure.BO.Coders;
using Pure.Dal.Coders.Toolbox;
using Pure.Library.CodeGenerator.Extensions;
using System.Reflection;
using Entity = Pure.Dal.Coders.Toolbox.Entities;

namespace Pure.Coders.Service.Mappers;

public static class ClassSpecificationMapper
{
    public static ClassSpecification Map(Type item)
    {
        return new()
        {
            AppearsInNamespace = item.GetNamespaceSafe(),
            Name = item.Name,
            Modifier = ModifierNames.Public,
            PropertySpecifications = PropertySpecificationMapper.Map([.. item.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)]),
            MethodSpecifications = MethodSpecificationMapper.Map([.. item.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Where(f => !f.IsSpecialName)])
        };
    }

    public static Entity.ClassSpecification Map(ClassSpecification item)
    {
        return new()
        {
            Id = string.IsNullOrEmpty(item.Id) ? Guid.NewGuid().ToString() : item.Id,
            AppearsInNamespace = item.AppearsInNamespace,
            Name = item.Name,
            Modifier = item.Modifier,
            PropertySpecifications = PropertySpecificationMapper.Map(item.PropertySpecifications),
            MethodSpecifications = MethodSpecificationMapper.Map(item.MethodSpecifications)
        };
    }

    public static ClassSpecification Map(Entity.ClassSpecification item)
    {
        return new()
        {
            Id = item.Id,
            AppearsInNamespace = item.AppearsInNamespace,
            Name = item.Name,
            Modifier = item.Modifier,
            PropertySpecifications = PropertySpecificationMapper.Map(item.PropertySpecifications.ToArray()),
            MethodSpecifications = MethodSpecificationMapper.Map(item.MethodSpecifications.ToArray())
        };
    }
}
