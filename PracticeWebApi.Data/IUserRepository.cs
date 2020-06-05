using PracticeWebApi.Data.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeWebApi.Data
{
    public interface IUserRepository
    {
        Task DeleteUser(string id);
        Task UpdateUser(UserDataEntity user);
        Task AddUser(UserDataEntity user);
        Task<UserDataEntity> FindUserById(string id);
        Task<IList<UserDataEntity>> GetAllUsers();
    }
}
