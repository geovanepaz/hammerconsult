using Domain;
using Domain.Interfaces;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ModeloContext context) : base(context)
        {
        }

        public async Task<bool> ExisteEmailAsync(string email)
        {
            var count = await Query().Where(x => x.Email.Equals(email)).CountAsync();
            return count > 0;
        }

        public async Task<bool> ExisteIdAsync(Guid id)
        {
            var count = await Query().Where(x => x.Id == id).CountAsync();
            return count > 0;
        }
    }
}
