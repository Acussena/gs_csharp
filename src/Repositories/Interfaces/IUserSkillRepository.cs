using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gs_csharp.src.Models;

namespace gs_csharp.src.Repositories.Interfaces
{
    public interface IUserSkillRepository
    {
        Task<UserSkill> Create(UserSkill skill);
        Task<UserSkill?> Get(int id);
        Task<IEnumerable<UserSkill>> GetAll();
        Task<IEnumerable<UserSkill>> GetByUser(int userId);
        Task<UserSkill> Update(UserSkill skill);
        Task<bool> Delete(int id);
    }
}