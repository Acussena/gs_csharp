using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gs_csharp.src.Data;
using gs_csharp.src.Models;
using gs_csharp.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gs_csharp.src.Repositories
{
    public class GapAnalysisRepository : IGapAnalysisRepository
    {
        private readonly AppDbContext _context;

        public GapAnalysisRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CareerGapAnalysis> Save(CareerGapAnalysis analysis)
        {
            _context.GapAnalyses.Add(analysis);
            await _context.SaveChangesAsync();
            return analysis;
        }

        public async Task<IEnumerable<CareerGapAnalysis>> GetByUser(int userId)
        {
            return await _context.GapAnalyses
                .Where(a => a.UserId == userId)
                .Include(a => a.FutureCareer)
                .ToListAsync();
        }
    }
}
