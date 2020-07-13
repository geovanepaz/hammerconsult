using Domain.DomainObjects;

namespace Domain
{
    public class Funcionario : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cargo { get; private set; }
        public string Setor { get; private set; }
        protected Funcionario() { }

        public Funcionario(string nome, string email, string cargo, string setor)
        {
            Nome = nome.Trim();
            Email = email.Trim();
            Cargo = cargo.Trim();
            Setor = setor.Trim();
            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio.");
            Validacoes.ValidarSeVazio(Email, "O campo Nome não pode estar vazio.");
            Validacoes.ValidarSeVazio(Cargo, "O campo Nome não pode estar vazio.");
            Validacoes.ValidarSeVazio(Setor, "O campo Nome não pode estar vazio.");
        }
    }
}
