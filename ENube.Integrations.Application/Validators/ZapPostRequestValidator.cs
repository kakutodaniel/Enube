using ENube.Integrations.Application.Contracts;
using ENube.Integrations.Application.Errors;
using ENube.Integrations.Application.Extensions;
using FluentValidation;

namespace ENube.Integrations.Application.Validators
{
    public class ZapPostRequestValidator : AbstractValidator<ZapPostRequest>
    {

        public ZapPostRequestValidator()
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.id_cliente)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.id_cliente)
                .GreaterThan(0)
                .WithMessage(EENubeErrors.CampoMaiorQueZero.GetDescription());

            RuleFor(x => x.interessado.nome)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());

            RuleFor(x => x.interessado.nome)
                .Length(4, 50)
                .When(x => !string.IsNullOrWhiteSpace(x.interessado.nome))
                .WithMessage(EENubeErrors.RangeCaracteres.GetDescription());


            RuleFor(x => x.interessado.email)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.interessado.email)
                .Must(x => x.IsValidEmail())
                .When(x => !string.IsNullOrWhiteSpace(x.interessado.email))
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription());


            RuleFor(x => x.interessado.telefone.ddd)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.interessado.telefone.ddd)
                .InclusiveBetween(11, 99)
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription());


            RuleFor(x => x.interessado.telefone.fone)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.interessado.telefone.fone)
                .Must(x => x.IsNumber())
                .When(x => !string.IsNullOrWhiteSpace(x.interessado.telefone.fone))
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription())
                .Length(8, 9)
                .When(x => !string.IsNullOrEmpty(x.interessado.telefone.fone))
                .WithMessage(EENubeErrors.RangeDigitos.GetDescription());

        }
    }
}
