using Microsoft.AspNetCore.Mvc;
using gs_csharp.src.Models;
using gs_csharp.src.Repositories.Interfaces;

namespace gs_csharp.src.Controllers.v1
{
    [ApiController]
    [Route("api/v1/future-careers")]
    public class FutureCareersController : ControllerBase
    {
        private readonly IFutureCareerRepository _repo;

        public FutureCareersController(IFutureCareerRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FutureCareer career)
        {
            return Ok(await _repo.Create(career));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }
    }
}
