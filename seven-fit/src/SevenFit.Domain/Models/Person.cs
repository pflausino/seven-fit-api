using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SevenFit.Domain.Enums;

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

        public Person(string email, string password, string name, Gender gender, AccessType accessType, DateTime birthDate)
        {
            SetEmail(email);
            SetPassword(password);
            SetName(name);
            SetBirthDate(birthDate);
            Gender = gender;
            AccessType = accessType;
        }
        public Int32 SetAge(DateTime birthDate)
        {
            var today = DateTime.Today;

            var todayAge = (today.Year * 100 + today.Month) * 100 + today.Day;
            var birthAge = (birthDate.Year * 100 + birthDate.Month) * 100 + birthDate.Day;

            return (todayAge - birthAge) / 10000;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            var age = SetAge(birthDate);
            if (age >= 18)
                BirthDate = birthDate;
            else
                throw new ArgumentException(nameof(birthDate));
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
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(password))
            {
                throw new ArgumentException("Password should contain At least one lower case letter");
            }
            else if (!hasUpperChar.IsMatch(password))
            {
                throw new ArgumentException("Password should contain At least one upper case letter");
            }
            else if (!hasMinMaxChars.IsMatch(password))
            {
                throw new ArgumentException("Password should not be less than 8 or greater than 15 characters");
            }
            else if (!hasNumber.IsMatch(password))
            {
                throw new ArgumentException("Password should contain At least one numeric value");
            }

            else if (!hasSymbols.IsMatch(password))
            {
                throw new ArgumentException("Password should contain At least one special case characters");
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