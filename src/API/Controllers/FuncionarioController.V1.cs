using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using Application.ViewModels.BadRequest;
using Application.ViewModels.Funcionario;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/funcionario")]
    [Authorize]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioAppService appService;

        public FuncionarioController(IFuncionarioAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BadRequest), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Adicionar(FuncionarioRequest request)
        {
            return Ok(await appService.AdicionarAsync(request));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<FuncionarioResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterTodosAsync()
        {
            return Ok(await appService.ObterTodosAsync());
        }
    }
}
