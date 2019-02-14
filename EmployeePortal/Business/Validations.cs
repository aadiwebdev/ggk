using Domain.StringLiterals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business
{
    class Validations
    {
        /// <summary>
        /// It is used to validate email
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static string ValidateEmailAddress(string emailAddress)
        {
            string pattern = @"^(([^<>()[\]\\.,;:\s@\""]+"
                + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(pattern);
            bool isMatch = reStrict.IsMatch(emailAddress);
            if (!isMatch)
            {
                return StringLiterals._invalidEmail;
            }
            return StringLiterals._success;
        }
        /// <summary>
        /// It is used to validate password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string ValidatePassword(string password)
        {

            var input = password;
            string errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                errorMessage = StringLiterals._invalidLowerCasePassword;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                errorMessage = StringLiterals._invalidUpperCasePassword;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                errorMessage = StringLiterals._invalidCharCountPassword;
            }
            else if (!hasNumber.IsMatch(input))
            {
                errorMessage = StringLiterals._invalidNumericPassword;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                errorMessage = StringLiterals._invalidSpecialSymbolPassword;
            }
            else
            {
                return StringLiterals._success;
            }
            return errorMessage;
        }
        /// <summary>
        /// It is used to validate name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ValidateName(string name)
        {

            string pattern = "^(\\b[A-Za-z]*\\b\\s+\\b[A-Za-z]*\\b+\\.[A-Za-z])$";
            Regex reStrict = new Regex(pattern);
            bool isMatch = reStrict.IsMatch(name);
            if (!isMatch)
            {
                return StringLiterals._invalidName;
            }
            return StringLiterals._success;
        }
    }
}


