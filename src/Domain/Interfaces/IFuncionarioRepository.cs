using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<bool> ExisteEmailAsync(string email);
        Task<bool> ExisteIdAsync(Guid id);
    }
}
