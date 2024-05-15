using AutoMapper;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersInsurancePolicies.Models;
using UsersInsurancePolicies.Models.Dto;
using UsersInsurancePolicies.Repositories;
using UsersInsurancePolicies.Repositories.IRepository;

namespace UsersInsurancePolicies.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private ResponseDto _response;
        private IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                var users = await _userRepository.GetUsers();
                _response.Result = users;
                
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
                var user = await _userRepository.GetUserById(id);
                _response.Result = user;
                
            }
            catch (Exception ex)
            {

                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            return _response;

        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] UsersDto userDto)
        {
            try
            {
                Users obj = _mapper.Map<Users>(userDto);
                var isExist = await _userRepository.CheckForMailAdd(obj.Email.Trim().ToLower());
                if (!isExist)
                {
                    obj.Email = obj.Email.ToLower();
                    var newUser = await _userRepository.AddUser(obj);

                    _response.Result = _mapper.Map<UsersDto>(newUser);
                }
                else
                {
                    _response.Message = "Email already exists";
                    _response.IsSuccess = false;
                }
                
            }
            catch (Exception ex)
            {

                _response.Message = ex.Message.ToString();
                _response.IsSuccess = false;
            }
            
            return _response;

        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] UsersDto userDto)
        {
            try
            {
                Users obj = _mapper.Map<Users>(userDto);
                var isNotExist = await _userRepository.CheckForMailUpdate(obj);
                if (isNotExist)
                {
                    var updatedUser = await _userRepository.UpdateUser(obj);

                    _response.Result = _mapper.Map<UsersDto>(updatedUser);
                }
                else
                {
                    _response.Message = "User already exists";
                    _response.IsSuccess = false;
                }


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
        public ResponseDto Delete(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                
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
