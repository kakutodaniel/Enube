using System.ComponentModel;

namespace ENube.Integrations.Application.Errors
{
    public enum EENubeErrors
    {
        [Description("'{PropertyName}' é requerido")]
        Campo_Requerido,

        [Description("'{PropertyName}' inválido")]
        Email_Invalido,

        [Description("'{PropertyName}' deve ter entre 5 e 50 caracteres")]
        Range_Tamanho_5_a_50


    }
}
