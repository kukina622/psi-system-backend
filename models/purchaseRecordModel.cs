using System.ComponentModel.DataAnnotations;

namespace psi.model {
  class purchaseRecord {
    [Key] public int purchase_id { get; set; }
    public string purchase_type { get; set; } = string.Empty;
    public string purchase_name { get; set; } = string.Empty;
    public int purchase_price { get; set; }
    public int purchase_quantity { get; set; }
    public DateTime purchase_time { get; set; }
    public string purchase_manufacturer { get; set; } = string.Empty;
  }
}