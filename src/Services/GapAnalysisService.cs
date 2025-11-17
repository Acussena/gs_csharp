using System;
using System.Linq;
using System.Threading.Tasks;
using gs_csharp.src.Models;
using gs_csharp.src.Repositories.Interfaces;

namespace gs_csharp.src.Services
{
    public class GapAnalysisService
    {
        private readonly IUserRepository _userRepo;
        private readonly IFutureCareerRepository _careerRepo;
        private readonly IGapAnalysisRepository _analysisRepo;

        public GapAnalysisService(
            IUserRepository userRepo,
            IFutureCareerRepository careerRepo,
            IGapAnalysisRepository analysisRepo)
        {
            _userRepo = userRepo;
            _careerRepo = careerRepo;
            _analysisRepo = analysisRepo;
        }

        public async Task<CareerGapAnalysis> AnalyzeCareer(int userId, int careerId)
        {
            var user = await _userRepo.Get(userId);
            var career = await _careerRepo.Get(careerId);

            if (user == null)
                throw new Exception("User not found");

            if (career == null)
                throw new Exception("Future career not found");

            // Skills do usuário
            var userSkills = user.Skills
                .Select(s => s.NomeSkill.Trim().ToLower())
                .ToList();

            // Metaskills exigidas pela carreira (separadas por vírgula na descrição)
            var requiredMetaskills = career.Descricao
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(m => m.Trim().ToLower())
                .ToList();

            // Skills que o usuário não possui
            var missing = requiredMetaskills
                .Where(m => !userSkills.Any(u => u.Contains(m)))
                .ToArray(); // string[]

            // Calcula score
            int score = requiredMetaskills.Count == 0
                ? 0
                : (int)(((requiredMetaskills.Count - missing.Length) / (double)requiredMetaskills.Count) * 100);

            // Cria análise
            var analysis = new CareerGapAnalysis
            {
                UserId = userId,
                FutureCareerId = careerId,
                Score = score,
                MetaskillsFaltantes = missing
            };

            return await _analysisRepo.Save(analysis);
        }
    }
}
