using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersInsurancePolicies.Models
{
    public class InsurancePolicies
    {
        [Key]
        public int InsurancePolicyID { get; set; }
        [Required]
        public string PolicyNumber { get; set; }
        public int InsuranceAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public Users Users { get; set; }


        //[ForeignKey("Customer")]
        //public string CustomerID { get; set; }
        //public virtual Customer Customer { get; set; }

    }
}
