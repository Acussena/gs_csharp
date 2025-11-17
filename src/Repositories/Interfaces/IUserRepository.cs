using System.Collections.Generic;
using System.Threading.Tasks;
using gs_csharp.src.Models;

namespace gs_csharp.src.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User> Update(User user);
        Task<bool> Delete(int id);
    }
}
