using System;

namespace Application.ViewModels.Evento
{
    public class ParticipanteEventoRequest
    {
        public Guid EventoId { get; set; }
        public Guid FunionarioId     { get; set; }
        public Guid? ConvidadoId { get; set; }
        public decimal ValorComida { get; set; }
        public decimal ValorBebida { get; set; }
        public bool ConvidadoComBebida { get; set; }
        public bool FuncioanrioComBebida { get; set; }
    }
}
