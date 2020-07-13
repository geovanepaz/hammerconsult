using Domain.DomainObjects;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Evento : Entity
    {
        public string Descricao { get; private set; }
        public DateTime Data { get; private set; }
        public decimal CustoComida { get; private set; }
        public decimal CustoBebida { get; private set; }
        public List<ParticipanteEvento> Participantes { get; private set; }


        protected Evento() { }

        public Evento(string descricao, DateTime data, decimal custoComida, decimal custoBebida)
        {
            Descricao = descricao;
            Data = data;
            CustoComida = custoComida;
            CustoBebida = custoBebida;
            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao não pode estar vazio.");
            Validacoes.ValidarSeMenorQue(Data, DateTime.Today, "Data do evento não pode ser menor que a data atual.");
            Validacoes.ValidarSeNulo(CustoComida, "O campo CustoComida não pode estar vazio.");
            Validacoes.ValidarSeMenorQue(CustoComida, 0, "O campo CustoComida não pode ser menor que zero.");
            Validacoes.ValidarSeNulo(CustoBebida, "O campo Nome não pode estar vazio.");
            Validacoes.ValidarSeMenorQue(CustoBebida, 0, "O campo CustoBebida não pode ser menor que zero.");
        }
    }
}
