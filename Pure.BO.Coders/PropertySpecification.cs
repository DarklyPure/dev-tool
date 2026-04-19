using Pure.Library;
using Pure.Library.Extensions;
using System.Reflection;

namespace Pure.BO.Coders;

/// <summary>
/// Specification detailing a property on a class.
/// </summary>
public sealed class PropertySpecification
{
    #region Properties
    /// <summary>
    /// The primary key.
    /// </summary>
    /// <example>
    /// 1
    /// </example>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The primary key of the <see cref="ClassSpecification"/> that this appears on.
    /// </summary>
    public string ClassId { get; set; } = string.Empty;

    /// <summary>
    /// The name of the property.
    /// </summary>
    /// <example>
    /// TheProperty
    /// </example>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The <see cref="Type"/> of the <see cref="PropertySpecification"/>.
    /// </summary>
    /// <example>
    /// string
    /// </example>
    public string Type { get; set; } = string.Empty;

    public PropertyInfo? PropertyInfo { get; set; }

    public bool IsNumeric { get; set; }

    public bool IsDate { get; set; }

    public bool IsCollection { get; set; }

    public ClassSpecification? ClassSpecification { get; set; }

    public PropertySpecificationCodeImplementation[]? PropertySpecificationCodeImplementations { get; set; }
    #endregion

    #region Helpers
    public void GenerateCodeObjects()
    {
        PropertySpecificationCodeImplementations =
            [
                new(){
                    Id = Guid.NewGuid().ToString(),
                    Language = CodeLanguageNames.CSharp,
                    ImplementationType = CodeObjectNames.BuilderVariable,
                    PropertySpecificationId = Id,
                    Code = PropertyInfo!.ToVariable($"{CodeLanguageNames.CSharp}-{CodeObjectNames.BuilderVariable}")
                },
                new(){
                    Id = Guid.NewGuid().ToString(),
                    Language = CodeLanguageNames.Typescript,
                    ImplementationType = CodeObjectNames.Variable,
                    PropertySpecificationId = Id,
                    Code = PropertyInfo!.ToVariable($"{CodeLanguageNames.Typescript}-{CodeObjectNames.Variable}")
                },
                new(){
                    Id = Guid.NewGuid().ToString(),
                    Language = CodeLanguageNames.Typescript,
                    ImplementationType = CodeObjectNames.OneToOnePropertySet,
                    PropertySpecificationId = Id,
                    Code = PropertyInfo!.ToOneToOnePropertySet($"{CodeLanguageNames.Typescript}-{CodeObjectNames.OneToOnePropertySet}")
                },
                new(){
                    Id = Guid.NewGuid().ToString(),
                    Language = CodeLanguageNames.CSharp,
                    ImplementationType = CodeObjectNames.OneToOnePropertySet,
                    PropertySpecificationId = Id,
                    Code = PropertyInfo!.ToOneToOnePropertySet($"{CodeLanguageNames.CSharp}-{CodeObjectNames.OneToOnePropertySet}")
                }
            ];
    }
    #endregion
}
