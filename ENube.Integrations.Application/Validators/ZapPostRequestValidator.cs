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
                .Must(x => x != default(int))
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.id_cliente)
                .GreaterThan(0)
                .WithMessage(EENubeErrors.CampoMaiorQueZero.GetDescription());

            RuleFor(x => x.interessado.nome)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.interessado.nome)
                .Length(4, 50)
                .When(x => !string.IsNullOrWhiteSpace(x.interessado.nome))
                .WithMessage(EENubeErrors.RangeCaracteres.GetDescription());


            RuleFor(x => x.interessado.email)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.interessado.email)
                .Must(x => x.IsValidEmail())
                .When(x => !string.IsNullOrWhiteSpace(x.interessado.email))
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription());


            RuleFor(x => x.interessado.telefone.ddd)
                .Must(x => x != default(int))
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.interessado.telefone.ddd)
                .InclusiveBetween(11, 99)
                .WithMessage(EENubeErrors.CampoInvalido.GetDescription());


            RuleFor(x => x.interessado.telefone.fone)
                .Must(x => !string.IsNullOrEmpty(x))
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
