using System;

namespace Application.ViewModels.Evento
{
    public class EventoResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal CustoComida { get; set; }
        public decimal CustoBebida { get; set; }
    }
}
