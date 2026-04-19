namespace Pure.Library.Repository.Interfaces;

public interface IEntityAudit
{
    /// <summary>
    /// The date and time that the item was created
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// The username of the account that created the item
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// The date and time that the item was last modified
    /// </summary>
    public DateTime? Modified { get; set; }

    /// <summary>
    /// The username of the account that last modified the item
    /// </summary>
    public string? ModifiedBy { get; set; }
}
