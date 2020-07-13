using System;

namespace Application.ViewModels.Evento
{
    public class ParticipantesEventoResponse
    {
        public Guid Id { get; set; }
        public Guid EventoId { get; set; }
        public Guid ParticipanteId { get; set; }
        public Guid? ConvidadoId { get; set; }
        public decimal ValorComida { get; set; }
        public decimal ValorBebida { get; set; }
        public bool ConvidadoComBebida { get; set; }
        public bool ParticipanteComBebida { get; set; }
    }
}
