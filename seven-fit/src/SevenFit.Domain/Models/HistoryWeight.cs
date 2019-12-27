using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SevenFit.Domain.Models
{
    public abstract class HistoryWeight
    {
        public Double Weight { get; set; }
        public DateTime Date { get; set; }
        public Guid GymGoerId { get; set; }

        public HistoryWeight(Double weight, Guid gymGoerId)
        {
            Date = DateTime.Today;
            SetWeight(weight);
            SetGymGoerId(gymGoerId);
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
        public void SetGymGoerId(Guid gymGoerId)
        {
            Regex validGuid = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
            if (validGuid.IsMatch(gymGoerId.ToString()))
                GymGoerId = gymGoerId;
            else
                throw new ArgumentException(nameof(gymGoerId));
        }


    }
}
