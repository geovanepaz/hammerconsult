using Application.Interfaces;
using Application.ViewModels.BadRequest;
using Application.ViewModels.Evento;
using Application.ViewModels.Funcionario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/evento")]
    [Authorize]
    public class EventoController : ControllerBase
    {
        private readonly IEventoAppService appService;

        public EventoController(IEventoAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BadRequest), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Adicionar(EventoRequest request)
        {
            return Ok(await appService.AdicionarAsync(request));
        }

        [HttpPost]
        [Route("participante")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BadRequest), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AdicionarParticipantes(ParticipanteEventoRequest request)
        {
            return Ok(await appService.AdicionarParticipanteAsync(request));
        }

        [HttpPost]
        [Route("participante/cancelamento")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BadRequest), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CancelarParticipacaoAsync(CancelamentoRequest request)
        {
            await appService.CancelarParticipacaoAsync(request.ParticipanteId);
            return Ok();
        }

        [HttpPost]
        [Route("convidado/cancelamento")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BadRequest), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RemoverConvidadoAsync(CancelamentoRequest request)
        {
            await appService.RemoverConvidadoAsync(request.ParticipanteId);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EventoResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterTodosEventossAsync()
        {
            return Ok(await appService.ObterEventosAsync());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(EventoDetalhesResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterDetalhesAsync(Guid id)
        {
            EventoDetalhesResponse result = await appService.ObterDetalhesAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/arrecadacao")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BadRequest), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ObterTotalArrecadado(Guid id)
        {
            return Ok(await appService.TotalArrecadado(id));
        }

        [HttpGet]
        [Route("{id}/participante")]
        [ProducesResponseType(typeof(List<ParticipanteResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterParticipantesAsync(Guid id)
        {
            return Ok(await appService.ObterParticipantesAsync(id));
        }

        [HttpGet]
        [Route("{id}/convidado")]
        [ProducesResponseType(typeof(List<FuncionarioResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterConvidadosAsync(Guid id)
        {
            return Ok(await appService.ObterConvidadosAsync(id));
        }

        [HttpGet]
        [Route("{id}/custo")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterGastosAsync(Guid id)
        {
            return Ok(await appService.ObterGastosAsync(id));
        }

        [HttpGet]
        [Route("{id}/custo/comida")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterGastosComidaAsync(Guid id)
        {
            return Ok(await appService.ObterGastosComidaAsync(id));
        }

        [HttpGet]
        [Route("{id}/custo/bebida")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterGastosBebidaAsync(Guid id)
        {
            return Ok(await appService.ObterGastosBebidaAsync(id));
        }
    }
}
