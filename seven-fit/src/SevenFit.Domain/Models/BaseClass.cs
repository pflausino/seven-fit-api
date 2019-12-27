using System;
using System.Text.RegularExpressions;

namespace SevenFit.Domain.Models
{
    public abstract class BaseClass
    {
        public Guid Id { get; set; }

        public BaseClass(Guid id)
        {
            SetId(id);
        }
        public void SetId(Guid id)
        {
            Regex validGuid = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
            if (validGuid.IsMatch(id.ToString()))
                Id = id;
            else
                throw new ArgumentException(nameof(id));
        }
    }
}