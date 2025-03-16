using Microsoft.EntityFrameworkCore;
using ChecklistAPI.Domain;

namespace ChecklistAPI.Data;

public class ChecklistDbContext(DbContextOptions<ChecklistDbContext> options) : DbContext(options)
{
	public DbSet<ListItem> Item { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("checklist");
	}
}
