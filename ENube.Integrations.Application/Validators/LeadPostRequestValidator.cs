using ENube.Integrations.Application.Contracts;
using FluentValidation;
using ENube.Integrations.Application.Extensions;
using ENube.Integrations.Application.Errors;

namespace ENube.Integrations.Application.Validators
{
    public class LeadPostRequestValidator : AbstractValidator<PostRequest>
    {

        public LeadPostRequestValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.name)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.name)
                .Length(4, 50)
                .When(x => !string.IsNullOrWhiteSpace(x.name))
                .WithMessage(EENubeErrors.RangeTamanho4A50.GetDescription());

            RuleFor(x => x.emailAddress)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.emailAddress)
                .Must(x => x.EmailValido())
                .When(x => !string.IsNullOrWhiteSpace(x.emailAddress))
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription());

            RuleFor(x => x.phoneNumber)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.createdById)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.midia)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.empreendimentosId)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

        }

    }
}
