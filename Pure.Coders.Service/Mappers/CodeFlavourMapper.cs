using Pure.BO.Coders;
using Entity = Pure.Dal.Coders.Toolbox.Entities;

namespace Pure.Coders.Service.Mappers;

/// <summary>
/// Mapper for mapping to and from <see cref="Entity.CodeFlavour"/> objects and <see cref="CodeFlavour"/> objects.
/// </summary>
public static class CodeFlavourMapper
{
    /// <summary>
    /// Maps a <see cref="CodeFlavour"/> instance.
    /// </summary>
    /// <param name="value">A <see cref="CodeFlavour"/> instance.</param>
    /// <returns>An <see cref="Entity.CodeFlavour"/> instance.</returns>
    public static Entity.CodeFlavour Map(CodeFlavour value)
    {
        return new()
        {
            Name = value.Name,
            Description = value.Description,
            Extensions = value.Extension
        };
    }

    /// <summary>
    /// Maps aN <see cref="Entity.CodeFlavour"/> instance.
    /// </summary>
    /// <param name="value">An <see cref="Entity.CodeFlavour"/> instance.</param>
    /// <returns>A <see cref="CodeFlavour"/> instance.</returns>
    public static CodeFlavour Map(Entity.CodeFlavour value)
    {
        return new()
        {
            Name = value.Name,
            Description = value.Description,
            Extension = value.Extensions
        };
    }

    /// <summary>
    /// Maps an <see cref="Entity.CodeFlavour"/> collection.
    /// </summary>
    /// <param name="items">An <see cref="Entity.CodeFlavour"/> collection.</param>
    /// <returns>A <see cref="CodeFlavour"/> collection.</returns>
    public static CodeFlavour[] Map(Entity.CodeFlavour[] items)
        => [.. items.Select(item => Map(item))];

    /// <summary>
    /// Maps a <see cref="CodeFlavour"/> collection.
    /// </summary>
    /// <param name="items">A <see cref="CodeFlavour"/> collection.</param>
    /// <returns>An <see cref="Entity.CodeFlavour"/> collection.</returns>
    public static Entity.CodeFlavour[] Map(CodeFlavour[] items)
        => [.. items.Select(item => Map(item))];
}
