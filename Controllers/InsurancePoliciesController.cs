using AutoMapper;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersInsurancePolicies.Data;
using UsersInsurancePolicies.Models;
using UsersInsurancePolicies.Models.Dto;
using UsersInsurancePolicies.Repositories.IRepository;

namespace UsersInsurancePolicies.Controllers
{
    [Route("api/insurancepolicies")]
    [ApiController]
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;
        private ResponseDto _response;
        private IMapper _mapper;

        public InsurancePoliciesController(IInsurancePolicyRepository insurancePolicyRepository, IMapper mapper)
        {
            _insurancePolicyRepository = insurancePolicyRepository;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                var insurancePolicies = await _insurancePolicyRepository.GetInsurancePolicies();
                _response.Result = insurancePolicies;
                
            }
            catch (Exception ex)
            {

                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                var insurancePolicy = await _insurancePolicyRepository.GetInsurancePolicyById(id);
                _response.Result = insurancePolicy;
            }
            catch (Exception ex)
            {

                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
           
            return _response;
        }

        [HttpGet("GetPoliciesByUser/{userid}")]
        //[Route("{userid:int}")]
        public async Task<ResponseDto> GetPoliciesByUser([FromRoute] int userid)
        {
            try
            {
                var insurancePolicy = await _insurancePolicyRepository.GetInsurancePolicyByUserId(userid);
                _response.Result = insurancePolicy;
                
            }
            catch (Exception ex)
            {

                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;

        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] InsurancePoliciesDto insurancePoliciesDto)
        {
            try
            {
                InsurancePolicies obj = _mapper.Map<InsurancePolicies>(insurancePoliciesDto);
                var newInsurancePolicy = await _insurancePolicyRepository.AddInsurancePolicy(obj);

                _response.Result = _mapper.Map<InsurancePoliciesDto>(newInsurancePolicy);
                
            }
            catch (Exception ex)
            {

                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;

        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] InsurancePoliciesDto insurancePoliciesDto)
        {
            try
            {
                InsurancePolicies obj = _mapper.Map<InsurancePolicies>(insurancePoliciesDto);
                var updatedInsurancePolicy = await _insurancePolicyRepository.UpdateInsurancePolicy(obj);

                _response.Result = _mapper.Map<InsurancePoliciesDto>(updatedInsurancePolicy);
                
            }
            catch (Exception ex)
            {

                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;

        }

        [HttpDelete]
        [Route("{id:int}")]
        public  ResponseDto Delete(int id)
        {
            try
            {
                _insurancePolicyRepository.DeleteInsurancePolicy(id);
                
            }
            catch (Exception ex)
            {

                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;

        }

    }
}
