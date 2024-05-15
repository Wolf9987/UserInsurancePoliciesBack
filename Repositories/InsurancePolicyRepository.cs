using Microsoft.EntityFrameworkCore;
using System;
using UsersInsurancePolicies.Data;
using UsersInsurancePolicies.Models;
using UsersInsurancePolicies.Repositories.IRepository;

namespace UsersInsurancePolicies.Repositories
{
    public class InsurancePolicyRepository : IInsurancePolicyRepository
    {
        private readonly AppDbContext _db;
        public InsurancePolicyRepository(AppDbContext db) 
        {
            _db = db;   
        }
        public async Task<InsurancePolicies> AddInsurancePolicy(InsurancePolicies insurancePolicy)
        {
            var result = await _db.InsurancePolicies.AddAsync(insurancePolicy);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteInsurancePolicy(int insurancePolicyId)
        {
            var result = await _db.InsurancePolicies
                .FirstOrDefaultAsync(p => p.InsurancePolicyID == insurancePolicyId);
            if (result != null)
            {
                _db.InsurancePolicies.Remove(result);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<InsurancePolicies>> GetInsurancePolicies()
        {
            IEnumerable<InsurancePolicies> objList = await _db.InsurancePolicies.ToListAsync();
            return objList;
        }

        public async Task<InsurancePolicies> GetInsurancePolicyById(int insurancePolicyId)
        {
            InsurancePolicies objList = await _db.InsurancePolicies.
                FirstAsync(p => p.InsurancePolicyID == insurancePolicyId);
            return objList;
        }

        public async Task<IEnumerable<InsurancePolicies>> GetInsurancePolicyByUserId(int userId)
        {
            IEnumerable<InsurancePolicies> objList = await _db.InsurancePolicies
                .Where(p=>p.UserID == userId).ToListAsync();
            return objList;
        }

        public async Task<InsurancePolicies> UpdateInsurancePolicy(InsurancePolicies insurancePolicy)
        {
            var result = _db.InsurancePolicies.Update(insurancePolicy);
            await _db.SaveChangesAsync();
            return result.Entity;
            //var result = await _db.InsurancePolicies
            //    .FirstOrDefaultAsync(p => p.InsurancePolicyID == insurancePolicy.InsurancePolicyID);

            //if (result != null)
            //{
            //    result.PolicyNumber = insurancePolicy.PolicyNumber;
            //    result.StartDate = insurancePolicy.StartDate;
            //    result.EndDate = insurancePolicy.EndDate;
            //    result.PolicyNumber = insurancePolicy.PolicyNumber;
            //    result.InsuranceAmount = insurancePolicy.InsuranceAmount;
            //    result.UserID = insurancePolicy.UserID;


            //    await _db.SaveChangesAsync();

            //    return result;
            //}
            //return null;
        }
    }
}
