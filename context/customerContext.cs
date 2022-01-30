using Microsoft.EntityFrameworkCore;
using psi.model;

namespace psi.context {
  class customerContext : DbContext {
    public customerContext(DbContextOptions<customerContext> options) : base(options) { }
    public DbSet<customer> customers => Set<customer>();
  }
}