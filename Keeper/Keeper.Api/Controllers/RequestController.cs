using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Keeper.Library.Services;
using Keeper.Library.Models;

namespace Keeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService) 
        {
            this._requestService = requestService;
        }
    }
}
