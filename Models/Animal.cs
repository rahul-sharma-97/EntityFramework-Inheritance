namespace EntityFrameworkInheritance.Models
{
    internal class Animal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Legs { get; set; }

        public virtual string Info { 
            get 
            {
                return $"My name is {Name}";
            } 
        }
    }
}
