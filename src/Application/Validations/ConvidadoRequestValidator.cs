using Application.ViewModels.Convidado;
using FluentValidation;

namespace Application.ViewModels.Validations
{
    public class ConvidadoRequestValidator : AbstractValidator<ConvidadoRequest>
    {
        public ConvidadoRequestValidator()
        {
            RuleFor(o => o.Nome)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor(o => o.Email)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor(o => o.Email)
                .EmailAddress().WithMessage("{PropertyName} inválido");

            RuleFor(o => o.FuncionarioId)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

        }
    }
}
