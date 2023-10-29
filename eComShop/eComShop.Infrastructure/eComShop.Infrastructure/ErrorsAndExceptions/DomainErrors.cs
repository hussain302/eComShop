using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComShop.Infrastructure.ErrorsAndExceptions
{
    public static class DomainErrors
    {
        public static class Password
        {
            public const string NullOrEmpty = "Password cannot be null or empty.";
            public const string TooShort = "Password is too short.";
            public const string MissingLowercaseLetter = "Password is missing a lowercase letter.";
            public const string MissingUppercaseLetter = "Password is missing an uppercase letter.";
            public const string MissingDigit = "Password is missing a digit.";
            public const string MissingNonAlphaNumeric = "Password is missing a non-alphanumeric character.";
        }
    }
}
