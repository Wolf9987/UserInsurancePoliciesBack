using Microsoft.EntityFrameworkCore;
using UsersInsurancePolicies.Data;
using UsersInsurancePolicies.Models;
using UsersInsurancePolicies.Repositories.IRepository;

namespace UsersInsurancePolicies.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) 
        {
            _db = db;
        }
        public async Task<Users> AddUser(Users user)
        {
            var result = await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteUser(int userId)
        {
            var result = await _db.Users
                .FirstOrDefaultAsync(u => u.UserID == userId);
            if (result != null)
            {
                _db.Users.Remove(result);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Users> GetUserById(int userId)
        {
            Users objList = await _db.Users.
                FirstAsync(u => u.UserID == userId);
            return objList;
        }

        public async Task<bool> CheckForMailAdd(string userEmail)
        {
            Users objList = await _db.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            return objList!=null;
        }

        public async Task<bool> CheckForMailUpdate(Users user)
        {
            bool res;
            Users objList = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == user.Email);
            if (objList == null)
            {
                res = true;
            }
            else
            {
                if (objList.UserID != user.UserID)
                {
                    res = false;
                }
                else
                {
                    res = true;
                }
                
            }

            return res;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            IEnumerable<Users> objList = await _db.Users.ToListAsync();
            return objList;
        }

        public async Task<Users> UpdateUser(Users user)
        {
            var result = _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
    }
}
