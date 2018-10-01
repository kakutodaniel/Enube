﻿using System.ComponentModel;

namespace ENube.Integrations.Application.Errors
{
    public enum EENubeErrors
    {
        [Description("'{PropertyName}' é requerido")]
        CampoRequerido,

        [Description("'{PropertyName}' inválido")]
        CampoInvalido,

        [Description("'{PropertyName}' deve ter entre 4 e 50 caracteres")]
        RangeTamanho4A50,

        [Description("'{PropertyName}' deve ser maior que 0")]
        CampoMaiorQueZero,

        [Description("'{PropertyName}' deve ter no mínimo 8 dígitos")]
        Minimo8Digitos,

        [Description("Empresa informada não encontrada (empreendimentosId)")]
        EmpresaNaoEncontrada,

        [Description("Não autorizado")]
        Unauthorized

        
    }
}
