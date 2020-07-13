using System;

namespace Domain.DomainObjects
{
    public class Participante
    {
        public Guid ParticipanteId { get; set; }
        public Convidado Convidado { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
