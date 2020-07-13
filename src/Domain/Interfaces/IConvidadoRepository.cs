using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IConvidadoRepository : IRepository<Convidado>
    {
        Task<bool> ExisteEmailAsync(string email);
        Task<bool> ExisteIdAsync(Guid id);
    }
}
