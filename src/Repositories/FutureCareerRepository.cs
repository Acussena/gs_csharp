using System.Collections.Generic;
using System.Threading.Tasks;
using gs_csharp.src.Data;
using gs_csharp.src.Models;
using gs_csharp.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gs_csharp.src.Repositories
{
    public class FutureCareerRepository : IFutureCareerRepository
    {
        private readonly AppDbContext _context;

        public FutureCareerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FutureCareer> Create(FutureCareer career)
        {
            _context.FutureCareers.Add(career);
            await _context.SaveChangesAsync();
            return career;
        }

        public async Task<FutureCareer?> Get(int id)
        {
            return await _context.FutureCareers
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<FutureCareer>> GetAll()
        {
            return await _context.FutureCareers
                .ToListAsync();
        }
    }
}
