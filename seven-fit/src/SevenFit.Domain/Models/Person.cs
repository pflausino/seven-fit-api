using System;
using System.Collections.Generic;
using System.Text;

namespace SevenFit.Domain.Models
{
    public abstract class Person : BaseClass
    {
        public string Email { get; private set; }

        public Person(string email)
        {
            SetEmail(email);
        }

        public void SetEmail(string email)
        {
            if (email.Contains("@"))
                Email = email;
            else
                throw new ArgumentException(nameof(email));
        }
    }
}