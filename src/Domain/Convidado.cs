using Domain.DomainObjects;
using System;

namespace Domain
{
    public class Convidado : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }

        /// <summary>
        /// Apenas para informação e saber a relação do convidado com o funcionario na hora do cadastro.
        /// Para cadastrar em um evento pode ser relacionado a outro funcionario.
        /// </summary>
        public Guid FuncionarioId { get; private set; }
        public Funcionario Funcionario { get; private set; }

        protected Convidado() { }
        public Convidado(Guid funcionarioId, string nome, string email)
        {
            Nome = nome.Trim();
            Email = email.Trim();
            FuncionarioId = funcionarioId;
        }

        public void Validar()
        {
            Validacoes.ValidarSeNulo(FuncionarioId, "O campo FuncionarioId não pode estar vazio");
            Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
            Validacoes.ValidarSeVazio(Email, "O campo Email não pode estar vazio");
        }
    }
}
