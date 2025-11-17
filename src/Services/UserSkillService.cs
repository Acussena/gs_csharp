using gs_csharp.src.Models;
using gs_csharp.src.Repositories.Interfaces;

namespace gs_csharp.src.Services
{
    public class UserSkillService
    {
        private readonly IUserSkillRepository _repo;

        public UserSkillService(IUserSkillRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserSkill> Create(UserSkill skill)
        {
            return await _repo.Create(skill);
        }

        public async Task<UserSkill?> Get(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<IEnumerable<UserSkill>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<IEnumerable<UserSkill>> GetByUser(int userId)
        {
            return await _repo.GetByUser(userId);
        }

        public async Task<UserSkill?> Update(int id, UserSkill updated)
        {
            var existing = await _repo.Get(id);
            if (existing == null)
                return null;

            // atualiza os campos
            existing.NomeSkill = updated.NomeSkill;
            existing.Nivel = updated.Nivel;
            existing.UserId = updated.UserId;

            return await _repo.Update(existing);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }
    }
}
