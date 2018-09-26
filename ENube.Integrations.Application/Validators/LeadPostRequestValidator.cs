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
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription());


            RuleFor(x => x.name)
                .Length(5, 50)
                .When(x => !string.IsNullOrWhiteSpace(x.name))
                .WithMessage(EENubeErrors.Range_Tamanho_5_a_50.GetDescription());

            RuleFor(x => x.emailAddress)
                .NotEmpty()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription());

            RuleFor(x => x.emailAddress)
                .Must(x => x.EmailValido())
                .When(x => !string.IsNullOrWhiteSpace(x.emailAddress))
                .WithMessage(EENubeErrors.Email_Invalido.GetDescription());

            RuleFor(x => x.phoneNumber)
                .NotEmpty()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription());

            RuleFor(x => x.createdById)
                .NotEmpty()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription());

            RuleFor(x => x.createdById)
                .Length(5, 50)
                .When(x => !string.IsNullOrWhiteSpace(x.name))
                .WithMessage(EENubeErrors.Range_Tamanho_5_a_50.GetDescription());

            RuleFor(x => x.viuAlgumaComunicaoDoProduto)
                .NotEmpty()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription());

            RuleFor(x => x.empreendimentosId)
                .NotEmpty()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription())
                .NotNull()
                .WithMessage(EENubeErrors.Campo_Requerido.GetDescription());

        }

    }
}
