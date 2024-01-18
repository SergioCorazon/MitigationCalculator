using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitigationCalculator.Models
{
    internal class Field : Attribute
    {
        public string value;

        public Field(string value)
        {
            this.value = value;
        }
    }
}