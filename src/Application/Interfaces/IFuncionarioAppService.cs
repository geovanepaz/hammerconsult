using Application.ViewModels.Funcionario;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFuncionarioAppService : IDisposable
    {
        Task<Guid> AdicionarAsync(FuncionarioRequest request);
        Task<IEnumerable<FuncionarioResponse>> ObterTodosAsync();

    }
}
