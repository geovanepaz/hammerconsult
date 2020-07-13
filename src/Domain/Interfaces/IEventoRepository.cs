using Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEventoRepository : IRepository<Evento>
    {
        /// <summary>
        /// Insere participantes do evento.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoCommit"></param>
        /// <returns></returns>
        Task<ParticipanteEvento> InsertParticipantes(ParticipanteEvento entity, bool autoCommit = true);
        Task RemoverParticipante(ParticipanteEvento participante);
        Task AtualizarParticipante(ParticipanteEvento participante);
        Task<EventoDetalhes> ObterDetalhesAsync(Guid eventoId);

        /// <summary>
        /// Verifica se ja existe algum evento cadastrado nesta data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>bool</returns>
        Task<bool> ExisteEventoNaData(DateTime data);
        Task<IEnumerable<Participante>> ObterParticipantesAsync(Guid eventoId);
        Task<IEnumerable<Convidado>> ObterConvidadosAsync(Guid eventoId);
        IQueryable<ParticipanteEvento> QueryParticipante();

        /// <summary>
        /// Verifica se o participante ja foi cadastrado.
        /// </summary>
        /// <param name="participanteId"></param>
        /// <param name="eventoId"></param>
        /// <returns></returns>
        Task<bool> FuncionarioEstaNoEvento(Guid funcionarioId, Guid eventoId);

        /// <summary>
        ///   Verifica se convidado ja foi cadastrado.
        /// </summary>
        /// <param name="convidadoId"></param>
        /// <param name="eventoId"></param>
        /// <returns></returns>
        Task<bool> ConvidadoJaCadastrado(Guid convidadoId, Guid eventoId);
        Task<bool> ExisteEvento(Guid eventoId);
        Task<decimal> ObterTotalArrecadado(Guid eventoId);
        Task<decimal> ObterTotalGasto(Guid eventoId);
        Task<decimal> ObterGastosComida(Guid eventoId);
        Task<decimal> ObterGastosBebida(Guid eventoId);
        Task<ParticipanteEvento> ObterParticipante(Guid id);
    }
}
