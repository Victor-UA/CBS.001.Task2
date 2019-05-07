using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Month : IEquatable<Month>
    {
        public string Name { get; }
        public uint Number { get; }
        public uint DaysQuantity { get; }

        public Month(string name, uint number, uint daysQuantity)
        {
            Name = name;
            Number = number;
            DaysQuantity = daysQuantity;
        }       

        public bool Equals(Month other)
        {
            return other != null &&
                   Name == other.Name &&
                   Number == other.Number &&
                   DaysQuantity == other.DaysQuantity;
        }

        public override int GetHashCode()
        {
            var hashCode = -479505591;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            hashCode = hashCode * -1521134295 + DaysQuantity.GetHashCode();
            return hashCode;
        }
    }
}
