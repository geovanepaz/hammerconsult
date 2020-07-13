using System;

namespace Application.ViewModels.Funcionario
{
    public class FuncionarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set; }
    }
}
