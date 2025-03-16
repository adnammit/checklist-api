namespace ChecklistAPI.Domain;

public abstract class BaseEntity
{
	public int Id { get; set; }
	// public Guid Id { get; set; } = Guid.NewGuid();
	// public Guid ModifiedBy { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
	public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
	public bool Active { get; set; } = true;
}
