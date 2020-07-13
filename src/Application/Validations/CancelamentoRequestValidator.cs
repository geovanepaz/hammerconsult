using Application.ViewModels.Evento;
using FluentValidation;

namespace Application.ViewModels.Validations
{
    public class CancelamentoRequestValidator : AbstractValidator<CancelamentoRequest>
    {
        public CancelamentoRequestValidator()
        {
            RuleFor(o => o.ParticipanteId)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

        }
    }
}
