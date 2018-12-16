using System;
using System.Text.RegularExpressions;

namespace ENube.Integrations.Application.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string value)
        {
            var regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return regex.IsMatch(value);
        }

        public static string GetFirstName(this string value)
        {
            return value.Split(" ")[0];
        }

        public static string GetLastName(this string value)
        {
            var collection = value.Split(" ");
            return collection.Length > 1 ? collection[1] : string.Empty;
        }

        public static bool IsNumber(this string value)
        {
            return long.TryParse(value, out long result);
        }

        public static bool IsValidDate(this string value)
        {
            return DateTime.TryParse(value, out DateTime result);
        }

    }
}
