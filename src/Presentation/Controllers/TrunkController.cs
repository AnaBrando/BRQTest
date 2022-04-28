using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly ILogger<TruckController> _logger;
        private readonly IMediator _mediator;
        public TruckController(ILogger<TruckController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        //TODO
        //RENOMEAR
        [HttpGet]
        public ActionResult Get(CancellationToken token)
        {
            return Ok("ok");
        }

        [HttpPost]       
        [ProducesResponseType(typeof(CreateTruckRequest),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateTruckRequest createTruckRequest,CancellationToken token)
        {
            var input = createTruckRequest.CreateRequestToCommand();
            var result = await _mediator.Send(input,token).ConfigureAwait(false);
            if (result.Succes){
                return Created(Constants.CreateSuccess.SuccessDefault(),result);
            }
            return BadRequest(Constants.CreateSuccess.ErrorDefault());
        }
    }
}
