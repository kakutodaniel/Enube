using System;
using System.ComponentModel;

namespace ENube.Integrations.Application.Extensions
{
    public static class EnumErrorsExtensions
    {

        public static string GetDescription(this Enum @enum)
        {

            var fi = @enum.GetType().GetField(@enum.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return @enum.ToString();

        }

    }
}
