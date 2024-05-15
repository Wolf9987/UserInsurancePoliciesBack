using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UsersInsurancePolicies.Models.Dto
{
    public class InsurancePoliciesDto
    {
      
        public int InsurancePolicyID { get; set; }
        public string PolicyNumber { get; set; }
        public int InsuranceAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserID { get; set; }
        public UsersDto? Users { get; set; }
    }
}
