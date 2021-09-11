using System.Text.RegularExpressions;

namespace FluentValidationNET5
{
    public static class StringExtensions
    {
        // Extension Method String
        public static bool IsValidDocument(this string document)
        {
            var expression = "[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{2}";

            return Regex.Match(document, expression).Success;
        }
    }
}