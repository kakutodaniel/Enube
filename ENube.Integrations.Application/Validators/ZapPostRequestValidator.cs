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
                .Length(5, 50)
                .When(x => !string.IsNullOrWhiteSpace(x.interessado.nome))
                .WithMessage(EENubeErrors.RangeTamanho5A50.GetDescription());


            RuleFor(x => x.interessado.email)
                .NotEmpty()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.CampoRequerido.GetDescription());


            RuleFor(x => x.interessado.email)
                .Must(x => x.EmailValido())
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
                .MinimumLength(8)
                .WithMessage(EENubeErrors.Minimo8Digitos.GetDescription());

        }
    }
}
