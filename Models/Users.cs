using System.ComponentModel.DataAnnotations;

namespace UsersInsurancePolicies.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
