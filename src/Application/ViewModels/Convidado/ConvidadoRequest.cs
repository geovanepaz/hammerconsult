using System;

namespace Application.ViewModels.Convidado
{
    public class ConvidadoRequest
    {
        public Guid FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
