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
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.name)
                .Length(4, 50)
                .When(x => !string.IsNullOrWhiteSpace(x.name))
                .WithMessage(EENubeErrors.RangeCaracteres.GetDescription());

            RuleFor(x => x.emailAddress)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.emailAddress)
                .Must(x => x.IsValidEmail())
                .When(x => !string.IsNullOrWhiteSpace(x.emailAddress))
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription());

            RuleFor(x => x.phoneNumber)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.phoneNumber)
                ////.Must(x => x.IsNumber())
                //.When(x => !string.IsNullOrWhiteSpace(x.phoneNumber))
                //.WithMessage(EENubeErrors.CampoInvalido.GetDescription())
                .Length(8, 15)
                .When(x => !string.IsNullOrEmpty(x.phoneNumber))
                .WithMessage(EENubeErrors.RangeDigitos.GetDescription());

            RuleFor(x => x.createdById)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.midia)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.empreendimentosId)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

        }

    }
}
