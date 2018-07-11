using System;
using System.Text.RegularExpressions;

namespace Cheeteye.Validators
{
    public static class EmailValidator
    {
        public static bool ValidateEmail(this string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                return false;
            }
            else
            {
                string regexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
                Match matches = Regex.Match(emailAddress, regexPattern);
                return matches.Success;
            }
        }
    }
}
