using Keeper.Library.Dto;
using Keeper.Library.Services;
using Keeper.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            return await _clientService.GetClients();
        }

        // GET: api/Client/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }

        // POST: api/Client
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientCreationDto dto)
        {
            int id = await _clientService.Add(dto);
            return CreatedAtAction("GetClient", new { id = id }, dto);
        }

        // PUT: api/Client/{id}
        [HttpPut]
        public async Task<IActionResult> PutClient(int id, ClientCreationDto dto)
        {

            await _clientService.Edit(id, dto);
            return NoContent();
        }

        // DELETE: api/Client/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            Client client = await _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            await _clientService.Remove(id);

            return NoContent();

        }

    }
}
