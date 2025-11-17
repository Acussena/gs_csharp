using System.Collections.Generic;
using System.Threading.Tasks;
using gs_csharp.src.Models;

namespace gs_csharp.src.Repositories.Interfaces
{
    public interface IFutureCareerRepository
    {
        Task<FutureCareer> Create(FutureCareer career);
        Task<FutureCareer?> Get(int id);
        Task<IEnumerable<FutureCareer>> GetAll();
    }
}
