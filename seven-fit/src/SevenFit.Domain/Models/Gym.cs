using System;
using System.Collections.Generic;
using System.Text;

namespace SevenFit.Domain.Models
{
    public abstract class Gym: BaseClass
    {
        public string Name { get; private set; }

        public Gym(string name)
        {
            Name = name;
        }
    }
}
