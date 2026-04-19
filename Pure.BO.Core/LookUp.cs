using System.ComponentModel.DataAnnotations;

namespace Pure.BO.Core;

public sealed class LookUp : Core
{
    #region Properties
    public List<LookUp>? Children { get; set; }
    /// <summary>
    /// The name of the the <see cref="LookUp"/>
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.A_NAME_IS_REQUIRED)]
    public string Name { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Optional - A note regarding this.
    /// </summary>
    public string? Note { get; set; }
    /// <summary>
    /// Specifies that the <see cref="LookUp"/> has been archived.
    /// </summary>
    public bool Archive { get; set; }
    #endregion
}
