using Microsoft.EntityFrameworkCore;
using psi.model;

namespace psi.context {
  class inventoryContext : DbContext {
    public inventoryContext(DbContextOptions<inventoryContext> options) : base(options) { }
    public DbSet<inventory> inventories => Set<inventory>();
  }
}