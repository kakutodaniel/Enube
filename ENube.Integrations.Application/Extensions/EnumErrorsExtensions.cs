using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

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

        public static bool EmailValido(this string email)
        {

            var rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return rg.IsMatch(email);
        }

    }
}
