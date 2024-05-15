using UsersInsurancePolicies.Models;

namespace UsersInsurancePolicies.Repositories.IRepository
{
    public interface IInsurancePolicyRepository
    {
        Task<IEnumerable<InsurancePolicies>> GetInsurancePolicies();
        Task<InsurancePolicies> GetInsurancePolicyById(int insurancePolicyId);
        Task<IEnumerable<InsurancePolicies>> GetInsurancePolicyByUserId(int userId);

        
        Task<InsurancePolicies> AddInsurancePolicy(InsurancePolicies insurancePolicy);
        Task<InsurancePolicies> UpdateInsurancePolicy(InsurancePolicies insurancePolicy);
        void DeleteInsurancePolicy(int insurancePolicyId);
    }
}
