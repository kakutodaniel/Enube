using ENube.Integrations.Application.Contracts;
using FluentValidation;

namespace ENube.Integrations.Application.Validators
{
    public class LeadPostRequestValidator : AbstractValidator<PostRequest>
    {

        public LeadPostRequestValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("'{PropertyName}' é requerido");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("'{PropertyName}' é requerido");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull()
                .WithMessage("'{PropertyName}' é requerido");

            RuleFor(x => x.CriadoPor)
                .NotEmpty()
                .NotNull()
                .WithMessage("'{PropertyName}' é requerido");

            RuleFor(x => x.ViuComunicacao)
                .NotEmpty()
                .NotNull()
                .WithMessage("'{PropertyName}' é requerido");

            RuleFor(x => x.EmpreendimentosIds)
                .NotEmpty()
                .NotNull()
                .WithMessage("'{PropertyName}' é requerido");



        }

    }
}
