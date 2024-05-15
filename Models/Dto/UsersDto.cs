using System.ComponentModel.DataAnnotations;

namespace UsersInsurancePolicies.Models.Dto
{
    public class UsersDto
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
