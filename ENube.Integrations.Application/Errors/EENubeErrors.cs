using System.ComponentModel;

namespace ENube.Integrations.Application.Errors
{
    public enum EENubeErrors
    {
        [Description("'{PropertyName}' é requerido")]
        CampoRequerido,

        [Description("'{PropertyName}' inválido")]
        EmailInvalido,

        [Description("'{PropertyName}' deve ter entre 5 e 50 caracteres")]
        RangeTamanho5A50


    }
}
