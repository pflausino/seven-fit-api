using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SevenFit.Domain.Models
{
    public abstract class Person : BaseClass
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public AccessType AccessType { get; private set; }
        public DateTime BirthDate { get; private set; }


        public Person(string email, string password, string name)
        {
            SetEmail(email);
            SetPassword(password);
            SetName(name);
        }

        public void SetEmail(string email)
        {
            if (email.Contains("@"))
                Email = email;
            else
                throw new ArgumentException(nameof(email));
        }

        public void SetPassword(string password)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,8}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be less than or greater than 8 characters";
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one special case characters";
            }
            else
            {
                Password = password;
            }
        }
            

        public void SetName(string name)
        {
            if (!name.Any(char.IsDigit))
                Name = name;
            else
                throw new ArgumentException(nameof(name));
        }


    }
}