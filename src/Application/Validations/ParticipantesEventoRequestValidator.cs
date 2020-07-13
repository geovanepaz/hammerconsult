using Application.ViewModels.Evento;
using FluentValidation;
using System;

namespace Application.ViewModels.Validations
{
    public class ParticipantesEventoRequestValidator : AbstractValidator<ParticipanteEventoRequest>
    {
        public ParticipantesEventoRequestValidator()
        {
            RuleFor(o => o.EventoId)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor(o => o.FunionarioId)
              .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor(o => o.ValorBebida)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor(o => o.ValorComida)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");
        }
    }
}
