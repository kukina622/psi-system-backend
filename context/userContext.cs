using Microsoft.EntityFrameworkCore;
using psi.model;

namespace psi.context {
  class userContext : DbContext {
    public userContext(DbContextOptions<userContext> options) : base(options) { }
    public DbSet<user> users => Set<user>();
  }
}