using Application.AutoMapper;
using Application.Interfaces;
using Application.ViewModels.Convidado;
using Application.ViewModels.Evento;
using AutoMapper;
using Domain;
using Domain.DomainObjects;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EventoAppService : IEventoAppService
    {
        private readonly IMapper _mapper;
        private readonly IEventoRepository _repository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IConvidadoRepository _convidadoRepository;

        public EventoAppService(IMapper mapper, IEventoRepository repository, IFuncionarioRepository funcionarioRepository, IConvidadoRepository convidadoRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _funcionarioRepository = funcionarioRepository;
            _convidadoRepository = convidadoRepository;
        }

        public async Task<Guid> AdicionarAsync(EventoRequest request)
        {
            Evento evento = ConverterParaModel(request);
            ValidaSeExisteEventoNaData(evento.Data);

            await _repository.InsertAsync(evento);
            return evento.Id;
        }

        public async Task<Guid> AdicionarParticipanteAsync(ParticipanteEventoRequest request)
        {
            ParticipanteEvento model = ConverterParticipanteParaModel(request);
            ValidacoesParticipanteEvento(model);

            await _repository.InsertParticipantes(model);
            return model.Id;
        }

        public async Task CancelarParticipacaoAsync(Guid participanteId)
        {
            await _repository.RemoverParticipante(ObterParticipante(participanteId));
        }

        public async Task RemoverConvidadoAsync(Guid participanteId)
        {
            var participante = ObterParticipante(participanteId);
            participante.RemoverConvidado();
            await _repository.AtualizarParticipante(participante);
        }

        public async Task<EventoDetalhesResponse> ObterDetalhesAsync(Guid eventoId)
        {
            var eventos = await _repository.ObterDetalhesAsync(eventoId);
            return eventos?.MapTo<EventoDetalhesResponse>(_mapper);
        }

        public async Task<IEnumerable<EventoResponse>> ObterEventosAsync()
        {
            var eventos = await _repository.AllAsync();
            return eventos?.MapTo<IEnumerable<EventoResponse>>(_mapper);
        }

        public async Task<IEnumerable<ParticipanteResponse>> ObterParticipantesAsync(Guid eventoId)
        {
            ValidaSeEncontraIdEvento(eventoId);

            var participantes = await _repository.ObterParticipantesAsync(eventoId);
            return participantes.MapTo<IEnumerable<ParticipanteResponse>>(_mapper);
        }

        public async Task<IEnumerable<ConvidadoResponse>> ObterConvidadosAsync(Guid eventoId)
        {
            ValidaSeEncontraIdEvento(eventoId);

            var convidados = await _repository.ObterConvidadosAsync(eventoId);
            return convidados.MapTo<IEnumerable<ConvidadoResponse>>(_mapper);
        }

        public async Task<decimal> TotalArrecadado(Guid eventoId)
        {
            ValidaSeEncontraIdEvento(eventoId);

            return await _repository.ObterTotalArrecadado(eventoId);
        }

        public async Task<decimal> ObterGastosAsync(Guid eventoId)
        {
            ValidaSeEncontraIdEvento(eventoId);

            return await _repository.ObterTotalGasto(eventoId);
        }

        public async Task<decimal> ObterGastosComidaAsync(Guid eventoId)
        {
            ValidaSeEncontraIdEvento(eventoId);

            return await _repository.ObterGastosComida(eventoId);
        }

        public async Task<decimal> ObterGastosBebidaAsync(Guid eventoId)
        {
            ValidaSeEncontraIdEvento(eventoId);

            return await _repository.ObterGastosBebida(eventoId);
        }

        /// <summary>
        /// Converte EventoRequest para Evento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private Evento ConverterParaModel(EventoRequest request)
        {
            return new Evento(request.Descricao, request.Data, request.CustoComida, request.CustoBebida);
        }

        /// <summary>
        /// Converte EventoRequest para Evento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private ParticipanteEvento ConverterParticipanteParaModel(ParticipanteEventoRequest request)
        {
            return new ParticipanteEvento(request.EventoId, request.FunionarioId, request.ConvidadoId,
                request.ValorComida, request.ValorBebida, request.ConvidadoComBebida, request.FuncioanrioComBebida);
        }

        /// <summary>
        /// Valida se existe evento na data.
        /// Caso já, retorna Exception.
        /// </summary>
        private void ValidaSeExisteEventoNaData(DateTime data)
        {
            bool existe = _repository.ExisteEventoNaData(data).Result;
            if (existe)
            {
                throw new DomainException("Já existe evento cadastrado nesta data.");
            }
        }

        /// <summary>
        ///  Faz validações sobre a regra de inserção do participante no evento. 
        ///  caso tenha erro, retorna Exception
        /// </summary>
        /// <param name="model"></param>
        private void ValidacoesParticipanteEvento(ParticipanteEvento model)
        {
            ValidaSeExisteEvento(model.EventoId);
            ValidaSeExisteFuncionario(model.FuncionarioId);

            if (model.ConvidadoId.HasValue)
            {
                ValidaSeExisteConvidado(model.ConvidadoId.Value);
            }

            ValidaFuncionarioNovento(model.FuncionarioId, model.EventoId);
            if (model.ConvidadoId.HasValue)
            {
                ValidaConvidadoNoEvento(model.ConvidadoId.Value, model.EventoId);
            }
        }

        /// <summary>
        /// Verifica se o id do evento existe. 
        /// caso não, Retorna Exception.
        /// </summary>
        /// <param name="eventoId"></param>
        private void ValidaSeExisteEvento(Guid eventoId)
        {
            bool existe = _repository.ExisteEvento(eventoId).Result;
            if (!existe)
            {
                throw new DomainException($"Evento não encontrado. {eventoId}");
            }
        }

        /// <summary>
        /// Verifica se o id do evento existe. 
        /// caso não, Retorna NotFound.
        /// </summary>
        /// <param name="eventoId"></param>
        private void ValidaSeEncontraIdEvento(Guid eventoId)
        {
            bool existe = _repository.ExisteEvento(eventoId).Result;
            if (!existe)
            {
                throw new NotFoundException();
            }
        }

        /// <summary>
        ///  Verifica  se o funcionario ja foi cadastardo no evento. 
        ///  Retorna Exception caso ja.
        /// </summary>
        /// <param name="participanteId"></param>
        /// <param name="eventoId"></param>
        private void ValidaFuncionarioNovento(Guid funcionarioId, Guid eventoId)
        {
            bool jaCadastrado = _repository
                                .FuncionarioEstaNoEvento(funcionarioId, eventoId)
                                .Result;
            if (jaCadastrado)
            {
                throw new DomainException("Funcionario ja  cadastrado no evento.");
            }
        }

        /// <summary>
        /// Verifica  se o convidado ja foi cadastardo no evento.
        /// Caso ja, retorna Exception.
        /// </summary>
        /// <param name="convidadoId"></param>
        /// <param name="eventoId"></param>
        private void ValidaConvidadoNoEvento(Guid convidadoId, Guid eventoId)
        {
            bool convidado = _repository
                            .ConvidadoJaCadastrado(convidadoId, eventoId)
                            .Result;
            if (convidado)
            {
                throw new DomainException("Convidado ja cadastrado no evento.");
            }
        }

        /// <summary>
        /// verifica se existe o id do convidado. 
        /// Caso não, retorna Exception.
        /// </summary>
        /// <param name="convidadoId"></param>
        private void ValidaSeExisteConvidado(Guid convidadoId)
        {
            bool existeConvidado = _convidadoRepository.ExisteIdAsync(convidadoId).Result;
            if (!existeConvidado)
            {
                throw new DomainException("Convidado não encontrado.");
            }
        }

        /// <summary>
        /// Verifica se o id do funcionario existe; 
        /// Caso não, retorna Exception.
        /// </summary>
        /// <param name="participanteId"></param>
        private void ValidaSeExisteFuncionario(Guid funcionarioId)
        {
            bool existe = _funcionarioRepository.ExisteIdAsync(funcionarioId).Result;
            if (!existe)
            {
                throw new DomainException("Funcionario não encontrado.");
            }
        }

        /// <summary>
        /// Busca Participante.
        /// Caso não encontre, retorna Exception.
        /// </summary>
        /// <param name="participanteId"></param>
        private ParticipanteEvento ObterParticipante(Guid participanteId)
        {
            ParticipanteEvento participante = _repository.ObterParticipante(participanteId).Result;
            if (participante == null)
            {
                throw new DomainException("Participante não encontrado.");
            }
            return participante;
        }

        public void Dispose()
        {
            _repository?.Dispose();
            _funcionarioRepository?.Dispose();
            _convidadoRepository?.Dispose();
        }
    }
}
