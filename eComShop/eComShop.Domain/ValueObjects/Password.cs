using eComShop.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComShop.Domain.ValueObjects
{
    /// <summary>
    /// Represents the password value object.
    /// </summary>
    public class Password
    {
        public string Value { get; }

        private Password(string password)
        {
            Value = password;
        }

        public static Password Create(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or empty");
            }

            if (password.Length < MinPasswordLength)
            {
                throw new ArgumentException("Password is too short");
            }

            if (!password.Any(char.IsLower))
            {
                throw new ArgumentException("Password is missing a lowercase letter");
            }

            if (!password.Any(char.IsUpper))
            {
                throw new ArgumentException("Password is missing an uppercase letter");
            }

            if (!password.Any(char.IsDigit))
            {
                throw new ArgumentException("Password is missing a digit");
            }

            if (!password.Any(IsNonAlphaNumeric))
            {
                throw new ArgumentException("Password is missing a non-alphanumeric character");
            }

            return new Password(password);
        }

        private static bool IsNonAlphaNumeric(char c)
        {
            return !char.IsLetterOrDigit(c);
        }

        private const int MinPasswordLength = 8;
    }

}
