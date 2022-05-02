using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamApi.Entities;
using TeamApi.Services;

namespace TeamApi.Controllers
{
    [Controller]

    [Route("api/[controller]")]
    public class MembrosController : Controller{

        private readonly MongoDBService _mongoDBService;


        public MembrosController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Membro>> Get() {
            return await _mongoDBService.GetAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Membro membro) {
            await _mongoDBService.CreateAsync(membro);

            return CreatedAtAction(nameof(Get), new { id = membro.Id }, membro);
        }

        

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToMembros(string id, [FromBody] string membroId) {
            await _mongoDBService.AddToMembrosAsync(id, membroId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }


    }
}
