using FluentValidation;
using Application.ViewModels.Login;

namespace Application.ViewModels.Validations
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(o => o.Email)
                .EmailAddress().WithMessage("{PropertyName} inválido")
                .NotEmpty().WithMessage("{PropertyName}  é obrigatório");

            RuleFor(o => o.Senha)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória");
        }
    }
}
