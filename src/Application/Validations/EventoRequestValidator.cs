using Application.ViewModels.Evento;
using FluentValidation;
using System;

namespace Application.ViewModels.Validations
{
    public class EventoRequestValidator : AbstractValidator<EventoRequest>
    {
        public EventoRequestValidator()
        {
            RuleFor(o => o.Descricao)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor(o => o.Data)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor(o => o.CustoComida)
               .Must(custoComida => custoComida >= 0).WithMessage("{PropertyName} não pode ser menor que zero.");

            RuleFor(o => o.CustoBebida)
                .Must(custoBebida => custoBebida >= 0).WithMessage("{PropertyName} não pode ser menor que zero.");


        }
    }
}
