namespace Data.Repository.Entities;

public class AuditableEntity
{
    public string? CreateBy { get; set; }
    public DateTime CreatedWhen { get; set; }
    public DateTime ModifiedWhen { get; set; }
    public string? ModifiedBy { get; set; }
}
