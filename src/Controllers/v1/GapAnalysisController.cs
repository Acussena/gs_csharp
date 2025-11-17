using Microsoft.AspNetCore.Mvc;
using gs_csharp.src.Services;

namespace gs_csharp.src.Controllers.v1
{
    [ApiController]
    [Route("api/v1/gap-analysis")]
    public class GapAnalysisController : ControllerBase
    {
        private readonly GapAnalysisService _service;

        public GapAnalysisController(GapAnalysisService service)
        {
            _service = service;
        }

        [HttpPost("{userId}/{careerId}")]
        public async Task<IActionResult> Analyze(int userId, int careerId)
        {
            var result = await _service.AnalyzeCareer(userId, careerId);
            return Ok(result);
        }
    }
}
