using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using MediatR;
using Application.UseCase.Queries.GetAllTruck;
using Presentation.Transport;

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
        [ProducesResponseType(typeof(ListTrucksQuery), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll(CancellationToken token)
        {
            var input = new ListTrucksQuery();
            var result = await _mediator.Send(input, token).ConfigureAwait(false);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost]       
        [ProducesResponseType(typeof(CreateTruckRequest),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateTruckRequest createTruckRequest,CancellationToken token)
        {
            var input = createTruckRequest.CreateRequestToCommand();
            var result = await _mediator.Send(input,token).ConfigureAwait(false);
            if (result.Success){
                return Created(Constants.CreateSuccess.SuccessDefault(),result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        [ProducesResponseType(typeof(UpdateTruckRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(UpdateTruckRequest updateTruckRequest, CancellationToken token)
        {
            var input = updateTruckRequest.UpdateRequestToCommand();
            var result = await _mediator.Send(input, token).ConfigureAwait(false);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(DeleteTruckRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(DeleteTruckRequest deleteTruckRequest, CancellationToken token)
        {
            var input = deleteTruckRequest.DeleteRequestToCommand();
            var result = await _mediator.Send(input, token).ConfigureAwait(false);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
