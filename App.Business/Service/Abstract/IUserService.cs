using App.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Abstract
{
    public interface IUserService
    {
        Task<List<User>>GetAllAsync();

        Task<List<User>>GetByUserAsync(int userId);

        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);

        Task<User> CheckUserAsync(string username);
    }
}
