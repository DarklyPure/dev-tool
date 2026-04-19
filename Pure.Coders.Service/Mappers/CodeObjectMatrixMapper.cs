using Pure.BO.Coders;
using Entity = Pure.Dal.Coders.Toolbox.Entities;

namespace Pure.Coders.Service.Mappers;

/// <summary>
/// Mapper for mapping to and from <see cref="Entity.CodeFlavour"/> objects and <see cref="CodeObjectMatrix"/> objects.
/// </summary>
public static class CodeObjectMatrixMapper
{
    /// <summary>
    /// Maps an <see cref="Entity.CodeObjectMatrix"/>.
    /// </summary>
    /// <param name="item">An <see cref="Entity.CodeObjectMatrix"/> instance.</param>
    /// <returns>A <see cref="CodeObjectMatrix"/> instance.</returns>
    public static CodeObjectMatrix Map(Entity.CodeObjectMatrix item)
    {
        return new()
        {
            CodeFlavour = item.CodeFlavour,
            CodeObject = item.CodeObject,
            InputType = item.InputType
        };
    }

    /// <summary>
    /// Maps a <see cref="CodeObjectMatrix"/> instance.
    /// </summary>
    /// <param name="item">A <see cref="CodeObjectMatrix"/>.</param>
    /// <returns>An <see cref="Entity.CodeObjectMatrix"/>.</returns>
    public static Entity.CodeObjectMatrix Map(CodeObjectMatrix item)
    {
        return new()
        {
            CodeFlavour = item.CodeFlavour,
            CodeObject = item.CodeObject,
            InputType = item.InputType
        };
    }

    /// <summary>
    /// Maps an <see cref="Entity.CodeObjectMatrix"/> collection.
    /// </summary>
    /// <param name="items">An <see cref="Entity.CodeObjectMatrix"/> collection.</param>
    /// <returns>A <see cref="CodeObjectMatrix"/> collection.</returns>
    public static CodeObjectMatrix[] Map(Entity.CodeObjectMatrix[] items)
        => [.. items.Select(item => Map(item))];

    /// <summary>
    /// Maps a <see cref="CodeObjectMatrix"/> collection.
    /// </summary>
    /// <param name="items">A <see cref="CodeObjectMatrix"/> collection.</param>
    /// <returns>An <see cref="Entity.CodeObjectMatrix"/> collection.</returns>
    public static Entity.CodeObjectMatrix[] Map(CodeObjectMatrix[] items)
        => [.. items.Select(item => Map(item))];
}
