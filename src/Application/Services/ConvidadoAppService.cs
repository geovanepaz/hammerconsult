using Application.AutoMapper;
using Application.Interfaces;
using Application.ViewModels.Convidado;
using AutoMapper;
using Domain;
using Domain.DomainObjects;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ConvidadoAppService : IConvidadoAppService
    {
        private readonly IMapper _mapper;
        private readonly IConvidadoRepository _repository;
        private readonly IFuncionarioRepository _participanteRepository;

        public ConvidadoAppService(IMapper mapper, IConvidadoRepository repository, IFuncionarioRepository participanteRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _participanteRepository = participanteRepository;
        }

        public async Task<Guid> AdicionarAsync(ConvidadoRequest request)
        {
            Convidado convidado = ConverterParaModel(request);

            ValidaSeExisteParticipante(convidado.FuncionarioId);
            ValidaSeExisteEmail(request.Email);

            await InserirAsync(convidado);
            return convidado.Id;
        }

        public async Task<IEnumerable<ConvidadoResponse>> ObterTodosAsync()
        {
            var convidados = await _repository.AllAsync();
            return convidados.MapTo<IEnumerable<ConvidadoResponse>>(_mapper);
        }

        /// <summary>
        /// Retorna exceção caso o email esteja sendo utilizado.
        /// </summary>
        /// <param name="email"></param>
        private void ValidaSeExisteEmail(string email)
        {
            bool existe = _repository.ExisteEmailAsync(email).Result;
            if (existe)
            {
                throw new DomainException("Email já cadastrado");
            }
        }

        /// <summary>
        /// Retorna exceção caso o patricipante não exista.
        /// </summary>
        /// <param name="participanteId"></param>
        private void ValidaSeExisteParticipante(Guid participanteId)
        {
            int count = _participanteRepository.Query(x => x.Id == participanteId).Count();
            if (count == 0)
            {
                throw new DomainException("Funcionario não encontrado");
            }
        }

        /// <summary>
        /// Converte ParticipanteRequest para Funcionario
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private Convidado ConverterParaModel(ConvidadoRequest request)
        {
            return new Convidado(request.FuncionarioId, request.Nome, request.Email);
        }

        private async Task InserirAsync(Convidado convidado)
        {
            await _repository.InsertAsync(convidado);
        }
        public void Dispose()
        {
            _repository?.Dispose();
            _participanteRepository?.Dispose();
        }
    }
}
