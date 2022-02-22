using System.ComponentModel.DataAnnotations;

namespace psi.model {
  class saleRecord {
    [Key] public int sale_id { get; set; }
    public int from_inventory { get; set; }
    public int to_customer  { get; set; }
    public int sale_quantity  { get; set; }
    public int sale_price  { get; set; }
    public DateTime sale_time  { get; set; }
  }
}