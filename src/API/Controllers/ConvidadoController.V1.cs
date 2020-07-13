using Application.Interfaces;
using Application.ViewModels.BadRequest;
using Application.ViewModels.Convidado;
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
    [Route("api/v{version:apiVersion}/convidado")]
    [Authorize]
    public class ConvidadoController : ControllerBase
    {
        private readonly IConvidadoAppService appService;

        public ConvidadoController(IConvidadoAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BadRequest), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Adicionar(ConvidadoRequest request)
        {
            return Ok(await appService.AdicionarAsync(request));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ConvidadoResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterTodosAsync()
        {
            return Ok(await appService.ObterTodosAsync());
        }
    }
}
