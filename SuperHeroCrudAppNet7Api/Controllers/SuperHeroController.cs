using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroCrudAppNet7Api.Models;
using SuperHeroCrudAppNet7Api.Services.SuperHeroService;

namespace SuperHeroCrudAppNet7Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _service;
        public SuperHeroController(ISuperHeroService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = await _service.GetAllHeroes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHero(int id)
        {
            var result= await _service.GetHero(id);
            if (result is null)
            {
                return NotFound("Superhero not Found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = await _service.AddHero(hero);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            var result = await _service.UpdateHero(hero);
            if (result is null)
            {
                return NotFound("Superhero not Found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _service.DeleteHero(id);
            if (result is null)
            {
                return NotFound("Superhero not Found");
            }
            return Ok(result);
        }

    }
}
