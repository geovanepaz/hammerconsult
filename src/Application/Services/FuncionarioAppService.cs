using Application.AutoMapper;
using Application.Interfaces;
using Application.ViewModels.Funcionario;
using AutoMapper;
using Domain;
using Domain.DomainObjects;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FuncionarioAppService : IFuncionarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IFuncionarioRepository _repository;

        public FuncionarioAppService(IMapper mapper, IFuncionarioRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Guid> AdicionarAsync(FuncionarioRequest request)
        {
            Funcionario participante = ConverterParaModel(request);
            ValidaSeExisteEmail(request.Email);

            await InserirAsync(participante);
            return participante.Id;
        }

        public async Task<IEnumerable<FuncionarioResponse>> ObterTodosAsync()
        {
            var convidados = await _repository.AllAsync();
            return convidados.MapTo<IEnumerable<FuncionarioResponse>>(_mapper);
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
        /// Converte FuncionarioRequest para Funcionario
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private Funcionario ConverterParaModel(FuncionarioRequest request)
        {
            return new Funcionario(request.Nome, request.Email, request.Cargo, request.Setor);
        }

        private async Task InserirAsync(Funcionario participante)
        {
            await _repository.InsertAsync(participante);
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
