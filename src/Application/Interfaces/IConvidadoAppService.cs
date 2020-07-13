using Application.ViewModels.Convidado;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IConvidadoAppService : IDisposable
    {
        Task<Guid> AdicionarAsync(ConvidadoRequest request);
        Task<IEnumerable<ConvidadoResponse>> ObterTodosAsync();

    }
}
