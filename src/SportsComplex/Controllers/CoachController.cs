using Microsoft.AspNetCore.Mvc;
using SportsComplex.Services.Interfaces;
using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService coachService;

        public CoachController(ICoachService coachService)
        {
            this.coachService = coachService ?? throw new ArgumentNullException(nameof(coachService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CoachDto>))]
        public async Task<IActionResult> GetList()
        {
            return Ok(await coachService.GetCoachesAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CoachDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await coachService.GetCoachAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CoachDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Create(CoachDto coachDto)
        {
            var coach = await coachService.CreateCoachAsync(coachDto);
            return CreatedAtAction(nameof(Get), new { id = coach.Id }, coach);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CoachDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Edit(int id, CoachDto coachDto)
        {
            return Ok(await coachService.UpdateCoachAsync(id, coachDto));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CoachDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            await coachService.DeleteCoachAsync(id);
            return NoContent();
        }
    }
}
