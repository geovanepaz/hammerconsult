using Application.ViewModels.Convidado;
using Application.ViewModels.Funcionario;
using System;

namespace Application.ViewModels.Evento
{
    public class ParticipanteResponse
    {
        public Guid ParticipanteId { get; set; }
        public ConvidadoResponse Convidado { get; set; }
        public FuncionarioResponse Funcionario { get; set; }
    }
}
