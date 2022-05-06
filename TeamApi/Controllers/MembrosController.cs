using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamApi.Entities;
using TeamApi.Services;

namespace TeamApi.Controllers
{
    [Controller]

    [Route("api/[controller]")]
    public class MembrosController : Controller{

        private readonly MembroService _mongoDBService;


        public MembrosController(MembroService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<Membro>> Get() {
            return await _mongoDBService.GetAsync();
        }
        

        [HttpPost]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Post([FromBody] Membro membro) {
            await _mongoDBService.CreateAsync(membro);

            return CreatedAtAction(nameof(Get), new { id = membro.Id }, membro);
        }

        

        [HttpPut("{id}")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> AddToMembros(string id, [FromBody] string membroId) {
            await _mongoDBService.AddToMembrosAsync(id, membroId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Delete(string id) {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }


    }
}
