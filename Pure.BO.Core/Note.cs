namespace Pure.BO.Core;

public sealed class Note
{
    #region Properties
    /// <summary>
    /// Date and time the note was created
    /// </summary>
    /// <value>
    /// 
    /// </value>
    public DateTime Created { get; set; } = DateTime.Now;
    /// <summary>
    /// The name of the creator
    /// </summary>
    public string? CreatedBy { get; set; }
    /// <summary>
    /// The date and time the note was last edited
    /// </summary>
    public DateTime Edited { get; set; } = DateTime.Now;
    /// <summary>
    /// The name of the account that last edited the note
    /// </summary>
    public string? EditedBy { get; set; }
    /// <summary>
    /// A short description of the note. Maximum 255 Characters
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// The body of the note
    /// </summary>
    public string? Content { get; set; }
    #endregion
}
