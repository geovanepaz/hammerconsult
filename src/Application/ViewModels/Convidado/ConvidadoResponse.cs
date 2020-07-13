using System;

namespace Application.ViewModels.Convidado
{
    public class ConvidadoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid FuncionarioId { get; set; }
    }
}
