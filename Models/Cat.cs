using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkInheritance.Models
{
    internal class Cat:Animal
    {
        public int Toys { get; set; }
        public override string Info {
            get
            {
                return $"{base.Info} and I am a Cat";
            }
        }
    }
}
