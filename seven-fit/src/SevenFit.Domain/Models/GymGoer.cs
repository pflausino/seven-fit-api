using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SevenFit.Domain.Enums;

namespace SevenFit.Domain.Models
{
    public abstract class GymGoer : Person
    {
        public string Objective { get; private set; }
        public HistoryWeight HistoryWeight { get; private set; }
        public Double Height { get; private set; }
        public Gym Gym { get; private set; }

        public GymGoer(Guid id, string email, string password, string name, Gender gender, AccessType accessType, DateTime birthDate, string objective, Double weight, Double height, Gym gym):
            base(id, email, password, name, gender, accessType, birthDate)
        {
            Objective = objective;
            Gym = gym;
            SetHeight(height);
           // HistoryWeight = new HistoryWeight(Double weight, Guid id);
            
        }
        public void SetHeight(Double height)
        {
            //Obrigatório ter 2 digitos depois do ponto
            var hasTwoDecimal = new Regex(@"^(?=.*[1-9])\d*(?:\.\d{2,2})$");
            
            if (hasTwoDecimal.IsMatch(height.ToString()))
                Height = height;
            else
                throw new ArgumentException(nameof(height));
        }

     


    }
}
