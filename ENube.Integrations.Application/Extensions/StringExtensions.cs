namespace ENube.Integrations.Application.Extensions
{
    public static class StringExtensions
    {
        public static string GetFirstName(this string name)
        {
            return name.Split(" ")[0];
        }

        public static string GetLastName(this string name)
        {
            var collection = name.Split(" ");
            return collection.Length > 1 ? collection[1] : string.Empty;
        }

    }
}
