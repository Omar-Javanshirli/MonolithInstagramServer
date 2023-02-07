using App.Business.Abstract;
using App.DataAccess.Abstract;
using App.DataAccess.Concrete.EfEntityFramework;
using App.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public UserService()
        {
            _userDal = new UserDal();
        }
        public async Task AddAsync(User user)
        {
            await _userDal.AddAsync(user);
        }

        public async Task<User> CheckUserAsync(string username)
        {
            var users = await _userDal.GetAllAsync();
            var user = users.FirstOrDefault();

            return user;
        }

        public async Task DeleteAsync(User user)
        {
            await _userDal.DeleteAsync(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userDal.GetAllAsync();
        }

        public async Task<List<User>> GetByUserAsync(int userId)
        {
            return await _userDal.GetAllAsync(u => u.UserId == userId.ToString());
        }

        public async Task UpdateAsync(User user)
        {
            await _userDal.UpdateAsync(user);
        }
    }
}
