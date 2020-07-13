using Domain.DomainObjects;
using System;

namespace Domain
{
    public class ParticipanteEvento : Entity
    {
        public Guid EventoId { get; private set; }
        public Guid FuncionarioId { get; private set; }
        public Guid? ConvidadoId { get; private set; }
        public decimal ValorComida { get; private set; }
        public decimal ValorBebida { get; private set; }
        public bool ConvidadoComBebida { get; private set; }
        public bool FuncionarioComBebida { get; private set; }
        public Funcionario Funcionario { get; private set; }
        public Convidado Convidado { get; private set; }
        public Evento Evento { get; private set; }


        protected ParticipanteEvento() { }

        public ParticipanteEvento(Guid eventoId, Guid funcionarioId, Guid? convidadoId, decimal valorComida, decimal valorBebida,
            bool convidadoComBebida, bool funcionarioComBebida)
        {
            EventoId = eventoId;
            FuncionarioId = funcionarioId;
            ConvidadoId = convidadoId;
            ValorComida = valorComida;
            ValorBebida = valorBebida;
            ConvidadoComBebida = convidadoId.HasValue ? convidadoComBebida : false;
            FuncionarioComBebida = funcionarioComBebida;
            Validar();
        }

        public void RemoverConvidado()
        {
            ValidaSeExisteConvidado();
            RemoveBebidaConvidado();

            ValorComida /= 2;
            ConvidadoId = null;
        }

        public void Validar()
        {
            Validacoes.ValidarSeNulo(FuncionarioId, "O campo FuncionarioId não pode estar vazio");
            ValidarValorBebida();
            ValidarValorComida();
        }

        private void ValidarValorBebida()
        {
            if (ConvidadoComBebida && FuncionarioComBebida)
            {
                if (ValorBebida < 20)
                {
                    throw new DomainException("Valor da bebida não pode ser menor que 20 reais, pois os dois irão beber.");
                }
            }

            if (ConvidadoComBebida || FuncionarioComBebida)
            {
                if (ValorBebida < 10)
                {
                    var solicitante = ConvidadoComBebida ? "convidado" : "funcionario";
                    throw new DomainException($"Valor da bebida não pode ser menor que 10 reais, pois o {solicitante} irá beber.");
                }
            }
        }

        private void ValidarValorComida()
        {
            if (ConvidadoId.HasValue)
            {
                if (ValorComida < 20)
                {
                    throw new DomainException("Valor da comida não pode ser menor que 20 reais, pois está levando um convidado.");
                }
            }

            if (ValorComida < 10)
            {
                throw new DomainException("Valor da comida não pode ser menor que 10 reais.");
            }
        }

        private void ValidaSeExisteConvidado()
        {
            if (!ConvidadoId.HasValue)
            {
                throw new DomainException("Este participante não possui convidado");
            }
        }

        private void RemoveBebidaConvidado()
        {
            if (FuncionarioComBebida && ConvidadoComBebida)
            {
                ValorBebida /= 2;
            }
            else if (ConvidadoComBebida)
            {
                ValorBebida = 0;
            }
            ConvidadoComBebida = false;
        }
    }
}
