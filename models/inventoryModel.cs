using System.ComponentModel.DataAnnotations;

namespace psi.model {
  class inventory {
    [Key] public int inventory_id { get; set; }
    public string inventory_type { get; set; } = string.Empty;
    public string inventory_name { get; set; } = string.Empty;
    public int purchase_price { get; set; }
    public int inventory_quantity { get; set; }
    public DateTime purchase_time { get; set; }
    public string purchase_manufacturer	 { get; set; } = string.Empty;
  }
}