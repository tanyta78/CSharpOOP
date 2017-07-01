using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatLady
{
    public class Cymric:Cat
    {
        private double furLength;

        public double FurLength
        {
            get { return furLength; }
            set { furLength = value; }
        }

        public override string ToString()
        {
            return $"{this.Breed} {this.Name} {this.FurLength:f2}";
        }
    }
}
