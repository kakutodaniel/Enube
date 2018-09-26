using ENube.Integrations.Application.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENube.Integrations.Application.Validators
{
    public class ZapPostRequestValidator : AbstractValidator<ZapPostRequest>
    {

        public ZapPostRequestValidator()
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            //TODO: add log

        }


    }
}
