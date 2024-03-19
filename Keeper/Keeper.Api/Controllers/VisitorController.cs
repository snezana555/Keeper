using Keeper.Library.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Keeper.Library.Models;
using Keeper.Library.Dto;

namespace Keeper.Api.Controllers
{
    [Route("swagger/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService _visitorService;
        public VisitorController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        // GET: api/Visitor
        [HttpGet]
        public async Task<ActionResult<List<Visitor>>> GetVisitors()
        {
            return await _visitorService.GetVisitors();
        }

        // GET: api/Visitor/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitor>> GetVisitor(int id)
        {
            var visitor = await _visitorService.GetVisitorById(id);
            if(visitor == null)
            {
                return NotFound();
            }
            return visitor;
        }

        // POST: api/Visitor
        [HttpPost]
        public async Task<ActionResult<Visitor>> PostVisitor(VisitorCreationDto dto)
        {
            int id = await _visitorService.Add(dto);
            return CreatedAtAction("GetVisitor", new {id = id}, dto);
        }

        // PUT: api/Visitor/{id}
        [HttpPut]
        public async Task<IActionResult> PutVisitor(int id, VisitorCreationDto dto)
        {

            await _visitorService.Edit(id, dto);
            return NoContent();
        }

        // DELETE: api/Visitor/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            Visitor visitor = await _visitorService.GetVisitorById(id);
            if(visitor == null)
            { 
                return NotFound();
            }

            await _visitorService.Remove(id);

            return NoContent();

        }

    }
}
