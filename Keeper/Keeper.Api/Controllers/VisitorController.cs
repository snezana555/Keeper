using Keeper.WebService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService _visitorService;
        public VisitorController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }
    }
}
