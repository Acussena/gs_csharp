using System.Collections.Generic;
using System.Threading.Tasks;
using gs_csharp.src.Models;

namespace gs_csharp.src.Repositories.Interfaces
{
    public interface IGapAnalysisRepository
    {
        Task<CareerGapAnalysis> Save(CareerGapAnalysis analysis);
        Task<IEnumerable<CareerGapAnalysis>> GetByUser(int userId);
    }
}
