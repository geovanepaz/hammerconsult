using Domain;
using Domain.DomainObjects;
using Domain.Interfaces;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        private readonly ISqlHelper _sqlHelper;

        public EventoRepository(ModeloContext context, IConfiguration configuration) : base(context)
        {
            _sqlHelper = new SqlHelper(configuration);
        }

        public async Task<ParticipanteEvento> InsertParticipantes(ParticipanteEvento entity, bool autoCommit = true)
        {
            await _context.ParticipanteEvento.AddAsync(entity);

            if (autoCommit)
            {
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task RemoverParticipante(ParticipanteEvento participante)
        {
            _context.ParticipanteEvento.Remove(participante);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarParticipante(ParticipanteEvento participante)
        {
            _context.ParticipanteEvento.Update(participante);
            await _context.SaveChangesAsync();
        }

        public async Task<EventoDetalhes> ObterDetalhesAsync(Guid eventoId)
        {
            var query = $@"
                           WITH arrecadacao (EventoId, TotalArrecadado, TotalArrecadadoBebida, TotalArrecadadoComida)
                            AS
                            (
                                SELECT 
	                            participantes.evento_id as EventoId,
	                            SUM(participantes.valor_bebida + participantes.valor_comida) AS TotalArrecadado,
	                            SUM(participantes.valor_bebida) AS TotalArrecadadoBebida,
	                            SUM(participantes.valor_comida) AS TotalArrecadadoComida
                                FROM 
	                                participantes_evento participantes 
                                WHERE 
	                                participantes.evento_id = '{eventoId}'
                                GROUP BY 
	                                participantes.evento_id
                            )

                            SELECT 
	                            e.id AS Id,
	                            e.data AS Data, 
	                            e.descricao AS Descricao, 
	                            e.custo_bebida + e.custo_comida AS CustoTotal,
	                            e.custo_bebida AS CustoBebida, 
	                            e.custo_comida AS CustoComida, 
	                            a.TotalArrecadado AS TotalArrecadado,
	                            A.TotalArrecadadoBebida AS TotalArrecadadoBebida,
	                            a.TotalArrecadadoComida as TotalArrecadadoComida
                            FROM 
	                            eventos AS e 
                            LEFT JOIN 
	                            arrecadacao a on a.EventoId = e.id
                            WHERE
                                e.id = '{eventoId}'
                        ";

            return await _sqlHelper.QuerySingleAsync<EventoDetalhes>(query);
        }

        public async Task<IEnumerable<Participante>> ObterParticipantesAsync(Guid eventoId)
        {
            return await _context.ParticipanteEvento
                                    .AsNoTracking()
                                    .Where(x => x.EventoId == eventoId)
                                    .Select(x => new Participante
                                    {
                                        ParticipanteId = x.Id,
                                        Convidado = x.Convidado,
                                        Funcionario = x.Funcionario
                                    })
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Convidado>> ObterConvidadosAsync(Guid eventoId)
        {
            return await _context.ParticipanteEvento
                                    .AsNoTracking()
                                    .Where(x => x.EventoId == eventoId && x.ConvidadoId != null)
                                    .Select(x => x.Convidado).ToListAsync();
        }

        public IQueryable<ParticipanteEvento> QueryParticipante()
        {
            return _context.ParticipanteEvento.AsNoTracking();
        }

        public async Task<decimal> ObterTotalArrecadado(Guid eventoId)
        {
            return await QueryParticipante()
                            .Where(x => x.EventoId == eventoId)
                            .SumAsync(x => x.ValorBebida + x.ValorComida);
        }

        public async Task<decimal> ObterTotalGasto(Guid eventoId)
        {
            return await Query()
                            .Where(x => x.Id == eventoId)
                            .SumAsync(x => x.CustoBebida + x.CustoComida);
        }

        public async Task<decimal> ObterGastosComida(Guid eventoId)
        {
            return await Query()
                            .Where(x => x.Id == eventoId)
                            .Select(x => x.CustoComida)
                            .FirstOrDefaultAsync();
        }

        public async Task<decimal> ObterGastosBebida(Guid eventoId)
        {
            return await Query()
                            .Where(x => x.Id == eventoId)
                            .Select(x => x.CustoBebida)
                            .FirstOrDefaultAsync();
        }

        public async Task<bool> FuncionarioEstaNoEvento(Guid funcionarioId, Guid eventoId)
        {
            var count = await QueryParticipante()
                                .Where(x => x.FuncionarioId == funcionarioId
                                        && x.EventoId == eventoId)
                                .CountAsync();

            return count > 0;
        }

        public async Task<bool> ConvidadoJaCadastrado(Guid convidadoId, Guid eventoId)
        {
            var count = await QueryParticipante()
                                .Where(x => x.ConvidadoId == convidadoId
                                        && x.EventoId == eventoId)
                                .CountAsync();

            return count > 0;
        }

        public async Task<ParticipanteEvento> ObterParticipante(Guid id)
        {
            return await QueryParticipante()
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteEventoNaData(DateTime data)
        {
            var count = await Query()
                                .Where(x =>
                                    x.Data.Year == data.Year
                                    && x.Data.Month == data.Month
                                    && x.Data.Day == data.Day)
                                .CountAsync();
            return count > 0;
        }

        public async Task<bool> ExisteEvento(Guid eventoId)
        {
            var count = await Query()
                                .Where(x => x.Id == eventoId)
                                .CountAsync();
            return count > 0;
        }

        public override void Dispose()
        {
            _sqlHelper?.Dispose();
            _context?.Dispose();
        }
    }
}
