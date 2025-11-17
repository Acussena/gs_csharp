using gs_csharp.src.Data;
using gs_csharp.src.Models;
using gs_csharp.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gs_csharp.src.Repositories
{
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly AppDbContext _context;

        public UserSkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserSkill> Create(UserSkill skill)
        {
            _context.UserSkills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<UserSkill?> Get(int id)
        {
            return await _context.UserSkills
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<UserSkill>> GetAll()
        {
            return await _context.UserSkills
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserSkill>> GetByUser(int userId)
        {
            return await _context.UserSkills
                .Where(s => s.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserSkill> Update(UserSkill skill)
        {
            _context.UserSkills.Update(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<bool> Delete(int id)
        {
            var skill = await Get(id);

            if (skill == null)
                return false;

            _context.UserSkills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
