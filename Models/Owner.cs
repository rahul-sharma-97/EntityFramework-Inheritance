using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkInheritance.Models
{
    internal class Owner
    {
        public int Id { get; set; }

        public ICollection<Animal> Animals { get; set; }

        public string Info
        {
            get
            {
                return $"I am an owner with {Animals.Count} animals";
            }
        }
    }
}
