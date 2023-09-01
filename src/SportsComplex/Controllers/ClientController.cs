using Microsoft.AspNetCore.Mvc;
using SportsComplex.Services.Interfaces;
using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClientDto>))]
        public async Task<IActionResult> GetList()
        {
            return Ok(await clientService.GetClientsAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await clientService.GetClientAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClientDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Create(ClientDto clientDto)
        {
            var client = await clientService.CreateClientAsync(clientDto);
            return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Edit(int id, ClientDto clientDto)
        {
            return Ok(await clientService.UpdateClientAsync(id, clientDto));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ClientDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            await clientService.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
