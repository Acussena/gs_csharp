using System.Collections.Generic;
using System.Threading.Tasks;
using gs_csharp.src.Models;
using gs_csharp.src.Repositories.Interfaces;

namespace gs_csharp.src.Services
{
    public class UserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task<User> Create(User user)
        {
            return _repo.Create(user);
        }

        public Task<User> Get(int id)
        {
            return _repo.Get(id);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<User> Update(User user)
        {
            return _repo.Update(user);
        }

        public Task<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
