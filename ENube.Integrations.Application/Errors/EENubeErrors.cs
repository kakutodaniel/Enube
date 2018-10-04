using System.ComponentModel;

namespace ENube.Integrations.Application.Errors
{
    public enum EENubeErrors
    {
        [Description("'{PropertyName}' é requerido")]
        CampoRequerido,

        [Description("'{PropertyName}' inválido")]
        CampoInvalido,

        [Description("'{PropertyName}' deve ter entre {MinLength} e {MaxLength} caracteres")]
        RangeCaracteres,

        [Description("'{PropertyName}' deve ser maior que 0")]
        CampoMaiorQueZero,

        [Description("'{PropertyName}' deve ter no mínimo {MinLength} dígitos")]
        QuantidadeMinimaDigitos,

        [Description("'{PropertyName}' deve ter no máximo {MaxLength} dígitos")]
        QuantidadeMaximaDigitos,

        [Description("'{PropertyName}' deve ter entre {MinLength} e {MaxLength} dígitos")]
        RangeDigitos,

        [Description("Empresa informada não encontrada (empreendimentosId)")]
        EmpresaNaoEncontrada,

        [Description("'{PropertyName}' deve ter {MaxLength} caracteres")]
        QuantidadeCaracteresFixo,

        [Description("Não autorizado")]
        Unauthorized

        
    }
}
