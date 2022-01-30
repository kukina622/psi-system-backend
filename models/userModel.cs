using System.ComponentModel.DataAnnotations;

namespace psi.model {
  class user {
    [Key] public int user_id { get; set; }
    public string username { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
  }
}