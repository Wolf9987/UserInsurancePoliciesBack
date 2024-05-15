using UsersInsurancePolicies.Models;

namespace UsersInsurancePolicies.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUserById(int userId);
        Task<Users> AddUser(Users user);
        Task<Users> UpdateUser(Users user);
        void DeleteUser(int userId);
        Task<bool> CheckForMailAdd(string userEmail);
        Task<bool> CheckForMailUpdate(Users user);
    }
}
