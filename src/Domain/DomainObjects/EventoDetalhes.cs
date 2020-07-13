using Domain.DomainObjects;
using System;
using System.Collections.Generic;

namespace Domain.DomainObjects
{
    public class EventoDetalhes
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal CustoTotal { get; set; }
        public decimal CustoComida { get; set; }
        public decimal CustoBebida { get; set; }
        public decimal TotalArrecadado { get; set; }
        public decimal TotalArrecadadoComida { get; set; }
        public decimal TotalArrecadadoBebida { get; set; }
    }
}
