using Microsoft.EntityFrameworkCore;
using psi.model;

namespace psi.context {
  class purchaseRecordContext : DbContext {
    public purchaseRecordContext(DbContextOptions<purchaseRecordContext> options) : base(options) { }
    public DbSet<purchaseRecord> purchase_record => Set<purchaseRecord>();
  }
}