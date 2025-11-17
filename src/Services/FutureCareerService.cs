using gs_csharp.src.Models;
using gs_csharp.src.Repositories.Interfaces;

namespace gs_csharp.src.Services
{
    public class FutureCareerService : IFutureCareerRepository
    {
        private readonly IFutureCareerRepository _repo;

        public FutureCareerService(IFutureCareerRepository repo)
        {
            _repo = repo;
        }

        public async Task<FutureCareer> Create(FutureCareer career)
        {
            return await _repo.Create(career);
        }

        public async Task<FutureCareer?> Get(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<IEnumerable<FutureCareer>> GetAll()
        {
            return await _repo.GetAll();
        }
    }
}
