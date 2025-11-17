using gs_csharp.src.Models;
using gs_csharp.src.Services;
using gs_csharp.src.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gs_csharp.src.Controllers.v1
{
    [ApiController]
    [Route("api/v1/userskills")]
    public class UserSkillsController : ControllerBase
    {
        private readonly UserSkillService _service;
        private readonly IUserRepository _userRepository;

        public UserSkillsController(UserSkillService service, IUserRepository userRepository)
        {
            _service = service;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserSkill skill)
        {
            var user = await _userRepository.Get(skill.UserId);
            if (user == null)
                return NotFound("Usuário não encontrado.");

            skill.User = null;

            var created = await _service.Create(skill);
            return Ok(created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var skill = await _service.Get(id);
            if (skill == null) return NotFound();

            return Ok(skill);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            return Ok(await _service.GetByUser(userId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserSkill updated)
        {
            var result = await _service.Update(id, updated);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
