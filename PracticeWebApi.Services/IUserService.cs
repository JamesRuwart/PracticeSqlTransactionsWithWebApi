using PracticeWebApi.CommonClasses.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeWebApi.Services
{
    public interface IUserService
    {
        Task DeleteUser(string id);
        Task UpdateUser(User user);
        Task<User> AddUser(User user);
        Task<User> FindUserById(string id);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
