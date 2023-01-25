using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketUpService.Domain.Commands.CreateClient;
using TicketUpService.Domain.Queries.GetClientesByStore;

namespace TicketUpService.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ClientController : BaseController
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetByStore()
        {
            var query = new GetClientesByStoreQuery(this.GetAuthUserStore());

            var data = await _mediator.Send(query);

            if (data is null)
            {
                return NotFound("Nenhum cliente encontrado para essa loja");
            }

            return Ok(data);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Create([FromBody] CreateClientCommand request)
        {
            request.SetStore( this.GetAuthUserStore());

            var data = await _mediator.Send(request);

            return Ok(data);
        }

    }
}
