using PracticeWebApi.CommonClasses.Users;
using PracticeWebApi.Data;
using PracticeWebApi.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApi.Services.Users
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper<User, UserDataEntity> _mapper;

        public UserService(IUserRepository userRepository, IMapper<User, UserDataEntity> mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> AddUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            ValidateUser(user);

            user.Id = Guid.NewGuid().ToString();

            var userDataEntity = _mapper.MapToDataEntity(user);

            await _userRepository.AddUser(userDataEntity);

            return user;
        }

        public async Task DeleteUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            await _userRepository.DeleteUser(id);
        }

        public async Task<User> FindUserById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            var userDataEntity = await _userRepository.FindUserById(id);
            var user = _mapper.MapToBase(userDataEntity);

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var userDataEntities = await _userRepository.GetAllUsers();
            var users = userDataEntities.Select(userDataEntity => _mapper.MapToBase(userDataEntity));

            return users;
        }

        public async Task UpdateUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(user.Id)) throw new ArgumentException($"{nameof(user.Id)} cannot be null or white space");
            ValidateUser(user);

            var userDataEntity = _mapper.MapToDataEntity(user);

            await _userRepository.UpdateUser(userDataEntity);
        }

        private void ValidateUser(User user)
        {
            if (user.Name is null) throw new ArgumentException($"{nameof(user.Name)} cannot be null");
            if (user.Address is null) throw new ArgumentException($"{nameof(user.Address)} cannot be null");
            if (string.IsNullOrWhiteSpace(user.Name.First)) throw new ArgumentException($"{nameof(user.Name.First)} cannot be null or white space");
            if (string.IsNullOrWhiteSpace(user.Name.Last)) throw new ArgumentException($"{nameof(user.Name.Last)} cannot be null or white space");
            if (string.IsNullOrWhiteSpace(user.Email)) throw new ArgumentException($"{nameof(user.Email)} cannot be null or white space");
            if (string.IsNullOrWhiteSpace(user.Address.Street)) throw new ArgumentException($"{nameof(user.Address.Street)} cannot be null or white space");
            if (string.IsNullOrWhiteSpace(user.Address.City)) throw new ArgumentException($"{nameof(user.Address.City)} cannot be null or white space");
            if (string.IsNullOrWhiteSpace(user.Address.State)) throw new ArgumentException($"{nameof(user.Address.State)} cannot be null or white space");
            if (string.IsNullOrWhiteSpace(user.Address.ZipCode)) throw new ArgumentException($"{nameof(user.Address.ZipCode)} cannot be null or white space");
        }
    }
}
