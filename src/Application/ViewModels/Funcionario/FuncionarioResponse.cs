using System;

namespace Application.ViewModels.Funcionario
{
    public class FuncionarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set; }
    }
}
