using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SevenFit.Domain.Models
{
    public class HistoryWeight
    {
        public Double Weight { get; set; }
        public DateTime Date { get; set; }
        public Guid GymGoerId { get; set; }

        public HistoryWeight(Double weight, Guid gymGoerId)
        {
            Date = DateTime.Today;
            SetWeight(weight);
            GymGoerId = gymGoerId;
        }
        public void SetWeight(Double weight)
        {
            //Obrigatório ter 3 digitos depois do ponto
            var hasThreeDecimal = new Regex(@"^(?=.*[1-9])\d*(?:\.\d{3,3})$");

            if (hasThreeDecimal.IsMatch(Weight.ToString()))
                Weight = weight;
            else
                throw new ArgumentException(nameof(weight));
        }
  


    }
}
