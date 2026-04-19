using Pure.BO.Coders;
using Pure.Dal.Coders.Toolbox;
using Pure.Library.Extensions;
using System.Reflection;
using Entity = Pure.Dal.Coders.Toolbox.Entities;

namespace Pure.Coders.Service.Mappers;

/// <summary>
/// Mapper for <see cref="MethodSpecification"/> business objects.
/// Mapper for <see cref="Entity.MethodSpecification"/> entities.
/// Mapper for <see cref="MethodInfo"/> reflection objects.
/// </summary>
public static class MethodSpecificationMapper
{
    /// <summary>
    /// Maps the passed <see cref="MethodInfo"/> reflection array.
    /// </summary>
    /// <param name="values">A <see cref="MethodInfo"/> reflection array.</param>
    /// <returns>A list of <see cref="MethodSpecification"/> business objects.</returns>
    public static MethodSpecification[] Map(MethodInfo[] values)
        => [.. values.Select(item => Map(item))];

    /// <summary>
    /// Maps the passed list of <see cref="MethodSpecification"/> business objects.
    /// </summary>
    /// <param name="values">A list of <see cref="MethodSpecification"/> business objects.</param>
    /// <returns>A list of <see cref="Entity.MethodSpecification"/> entities.</returns>
    public static Entity.MethodSpecification[] Map(MethodSpecification[] values)
        => [.. values.Select(item => Map(item))];

    public static MethodSpecification[] Map(Entity.MethodSpecification[] values)
        => [.. values.Select(item => Map(item))];

    /// <summary>
    /// Maps the passed list of <see cref="MethodSpecification"/> business objects.
    /// </summary>
    /// <param name="values">A list of <see cref="MethodSpecification"/> business objects.</param>
    /// <param name="classSpecification">A <see cref="ClassSpecification"/> instance.</param>
    /// <returns>A list of <see cref="Entity.MethodSpecification"/> entities.</returns>
    public static MethodSpecification[] Map(MethodSpecification[] values, ClassSpecification classSpecification)
        => [.. values.Select(item => Map(item, classSpecification))];

    /// <summary>
    /// Maps the passed <see cref="MethodSpecification"/> business object.
    /// </summary>
    /// <param name="value">A <see cref="MethodSpecification"/> business object.</param>
    /// <returns>A <see cref="Entity.MethodSpecification"/> entity.</returns>
    public static Entity.MethodSpecification Map(MethodSpecification value)
    {
        return new()
        {
            Id = string.IsNullOrEmpty(value.Id) ? Guid.NewGuid().ToString() : value.Id,
            ClassId = value.ClassId,
            Modifier = value.Modifier,
            Name = value.Name,
            ReturnType = value.ReturnType,
            ParameterSpecifications = ParameterSpecificationMapper.Map(value.ParameterSpecifications.ToArray())
        };
    }

    /// <summary>
    /// Maps the passed <see cref="MethodSpecification"/> business object.
    /// </summary>
    /// <param name="value">A <see cref="MethodSpecification"/> business object.</param>
    /// <param name="classSpecification">An <see cref="ClassSpecification"/> business object.</param>
    /// <returns>An <see cref="Entity.MethodSpecification"/> entity.</returns>
    public static MethodSpecification Map(MethodSpecification value, ClassSpecification classSpecification)
    {
        return new()
        {
            Id = value.Id,
            ClassId = classSpecification.Id,
            Modifier = value.Modifier,
            Name = value.Name,
            ReturnType = value.ReturnType,
            Note = value.Note
        };
    }

    /// <summary>
    /// Maps the passed <see cref="MethodInfo"/> reflection object.
    /// </summary>
    /// <param name="value">A <see cref="MethodInfo"/> reflection object.</param>
    /// <returns>A <see cref="MethodSpecification"/> business object.</returns>
    public static MethodSpecification Map(MethodInfo value)
    {
        return new()
        {
            Modifier = value.IsPublic ? ModifierNames.Public : ModifierNames.Private,
            Name = value.Name,
            ReturnType = value.ReturnType == typeof(void) ? "void" : value.ReturnType.CSharpTypeMapping(),
            ParameterSpecifications = ParameterSpecificationMapper.Map(value.GetParameters())
        };
    }

    public static MethodSpecification Map(Entity.MethodSpecification value)
    {
        return new()
        {
            Id = value.Id,
            ClassId = value.ClassId,
            Modifier = value.Modifier,
            Name = value.Name,
            ReturnType = value.ReturnType,
            ParameterSpecifications = ParameterSpecificationMapper.Map(value.ParameterSpecifications.ToArray())
        };
    }
}
