using Marketplace.DAL.Models;
using Marketplace.DAL.Repositories;
using PagedList;

namespace Marketplace.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Credential GetCredential(string username)
        {
            return _userRepository.GetCredential(username);
        }

        public User GetUser(string username)
        {
            return _userRepository.GetUser(username);
        }

        public IPagedList<User> GetUsers(int page, int itemsPerPage)
        {
            return _userRepository.GetUsers(page, itemsPerPage);
        }

        public void RemoveUser(string username)
        {
            _userRepository.RemoveUser(username);
        }

        public void SaveData(User user, Credential credential)
        {
            _userRepository.SaveData(user, credential);
        }
    }
}
