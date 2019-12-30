using SevenFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenFit.Domain.Models
{
    public class Personal: Person
    {
        public Personal(Guid id, string email, string password, string name, Gender gender, AccessType accessType, DateTime birthDate) :
    base(id, email, password, name, gender, accessType, birthDate)
        {
           

        }
    }
}
