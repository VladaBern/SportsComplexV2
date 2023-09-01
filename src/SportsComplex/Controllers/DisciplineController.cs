using Microsoft.AspNetCore.Mvc;
using SportsComplex.Services.Interfaces;
using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        private readonly IDisciplineService disciplineService;

        public DisciplineController(IDisciplineService disciplineService)
        {
            this.disciplineService = disciplineService ?? throw new ArgumentNullException(nameof(disciplineService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DisciplineDto>))]
        public async Task<IActionResult> GetList()
        {
            return Ok(await disciplineService.GetDisciplinesAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisciplineDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await disciplineService.GetDisciplineAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DisciplineDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Create(DisciplineDto disciplineDto)
        {
            var disc = await disciplineService.CreateDisciplineAsync(disciplineDto);
            return CreatedAtAction(nameof(Get), new { id = disc.Id }, disc);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisciplineDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Edit(int id, DisciplineDto disc)
        {
            return Ok(await disciplineService.UpdateDisciplineAsync(id, disc));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(DisciplineDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            await disciplineService.DeleteDisciplineAsync(id);
            return NoContent();
        }
    }
}
