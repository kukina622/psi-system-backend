using Microsoft.EntityFrameworkCore;
using psi.model;

namespace psi.context {
  class saleRecordContext : DbContext {
    public saleRecordContext(DbContextOptions<saleRecordContext> options) : base(options) { }
    public DbSet<saleRecord> sale_record => Set<saleRecord>();
  }
}