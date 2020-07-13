using Application.ViewModels.Convidado;
using Application.ViewModels.Evento;
using Application.ViewModels.Funcionario;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEventoAppService : IDisposable
    {
        Task<Guid> AdicionarAsync(EventoRequest request);
        Task<Guid> AdicionarParticipanteAsync(ParticipanteEventoRequest request);
        Task RemoverConvidadoAsync(Guid participanteId);
        Task CancelarParticipacaoAsync(Guid participanteId);
        Task<EventoDetalhesResponse> ObterDetalhesAsync(Guid eventoId);
        Task<IEnumerable<EventoResponse>> ObterEventosAsync();
        Task<IEnumerable<ParticipanteResponse>> ObterParticipantesAsync(Guid eventoId);
        Task<IEnumerable<ConvidadoResponse>> ObterConvidadosAsync(Guid eventoId);
        Task<decimal> ObterGastosAsync(Guid eventoId);
        Task<decimal> TotalArrecadado(Guid eventoId);
        Task<decimal> ObterGastosComidaAsync(Guid eventoId);
        Task<decimal> ObterGastosBebidaAsync(Guid eventoId);

    }
}
