using System.ComponentModel.DataAnnotations;

namespace psi.model {
  class customer {
    [Key] public int customer_id { get; set; }
    public string customer_name { get; set; } = string.Empty;
    public string? tax_ID { get; set; }
    public string? contact_person { get; set; }
    public string? phone { get; set; }
    public string? fax_number { get; set; }
    public string? customer_email { get; set; }
    public string? customer_address { get; set; }
  }
}