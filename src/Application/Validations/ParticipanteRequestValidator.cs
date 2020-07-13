using Application.ViewModels.Funcionario;
using FluentValidation;

namespace Application.ViewModels.Validations
{
    public class ParticipanteRequestValidator : AbstractValidator<FuncionarioRequest>
    {
        public ParticipanteRequestValidator()
        {
            RuleFor(o => o.Nome)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor(o => o.Email)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor(o => o.Email)
                .EmailAddress().WithMessage("{PropertyName} inválido");

            RuleFor(o => o.Cargo)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor(o => o.Setor)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");
        }
    }
}
