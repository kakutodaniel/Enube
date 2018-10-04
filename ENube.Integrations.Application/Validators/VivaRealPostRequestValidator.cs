using ENube.Integrations.Application.Contracts;
using ENube.Integrations.Application.Errors;
using ENube.Integrations.Application.Extensions;
using FluentValidation;
using System;

namespace ENube.Integrations.Application.Validators
{
    public class VivaRealPostRequestValidator : AbstractValidator<VivaRealPostRequest>
    {

        public VivaRealPostRequestValidator()
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.leadOrigin)
                 .NotEmpty()
                 .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                 .NotNull()
                 .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.timestamp)
                .NotEmpty()
                 .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                 .NotNull()
                 .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.timestamp)
                .Must(x => x.IsValidDate())
                 .When(x => !string.IsNullOrWhiteSpace(x.timestamp))
                 .WithMessage(EENubeErrors.CampoInvalido.GetDescription());


            RuleFor(x => x.originLeadId)
                 .NotEmpty()
                 .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                 .NotNull()
                 .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.originListingId)
                 .NotEmpty()
                 .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                 .NotNull()
                 .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.clientListingId)
                 .NotEmpty()
                 .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                 .NotNull()
                 .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.name)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.name)
                .Length(4, 50)
                .When(x => !string.IsNullOrWhiteSpace(x.name))
                .WithMessage(EENubeErrors.RangeCaracteres.GetDescription());

            RuleFor(x => x.email)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.email)
                .Must(x => x.IsValidEmail())
                .When(x => !string.IsNullOrWhiteSpace(x.email))
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription());

            RuleFor(x => x.ddd)
                .Must(x => x.IsNumber())
                .When(x => !string.IsNullOrWhiteSpace(x.ddd))
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription())
                .Length(2)
                .When(x => !string.IsNullOrWhiteSpace(x.ddd))
                .WithMessage(EENubeErrors.QuantidadeCaracteresFixo.GetDescription());


            RuleFor(x => x.phone)
                .Must(x => x.IsNumber())
                .When(x => !string.IsNullOrWhiteSpace(x.phone))
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription())
                .Length(8, 9)
                .When(x => !string.IsNullOrWhiteSpace(x.phone))
                .WithMessage(EENubeErrors.RangeDigitos.GetDescription());


            RuleFor(x => x.phoneNumber)
                .Must(x => x.IsNumber())
                .When(x => !string.IsNullOrWhiteSpace(x.phoneNumber))
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription())
                .Length(8, 9)
                .When(x => !string.IsNullOrWhiteSpace(x.phoneNumber))
                .WithMessage(EENubeErrors.RangeDigitos.GetDescription());


            RuleFor(x => x.message)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

        }

    }
}
