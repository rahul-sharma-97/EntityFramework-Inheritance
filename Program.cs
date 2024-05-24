// See https://aka.ms/new-console-template for more information
using EntityFrameworkInheritance.Infrastructure;
using EntityFrameworkInheritance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        CreateDB();

        ShowDBData();

    }

    private static Owner GetDefaultData()
    {
        return new Owner
        {
            Animals = new List<Animal>
                {
                    new Dog { Name = "Rover", Bones = 2 , Legs = 4 },
                    new Dog { Name = "another Dog", Bones = 4 , Legs = 4 },
                    new Cat { Name = "Tiddles", Toys = 4 , Legs = 4 },
                    new Cat { Name = "Felix",Toys = 4 , Legs = 4 }
                }
        };
    }

    private static void CreateDB() 
    { 
  
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var options = new DbContextOptionsBuilder<AnimalContext>()
            .UseSqlServer(config.GetConnectionString("AnimalsDB"))
            .Options;

        using var db = new AnimalContext(options);

        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        var owner = GetDefaultData();

        db.Owners.Add(owner);

        db.SaveChanges();
    }

    private static void ShowDBData()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var options = new DbContextOptionsBuilder<AnimalContext>()
            .UseSqlServer(config.GetConnectionString("AnimalsDB"))
            .Options;

        using var db = new AnimalContext(options);

        Console.WriteLine("From Owner:");
        Console.WriteLine(db.Owners.Include(o => o.Animals).First().Info);

        Console.WriteLine("All Animals:");

        foreach (var p in db.Animals)
            Console.WriteLine(p.Info);

        Console.WriteLine("\nAll Cats:");

        foreach (var c in db.Cats)
            Console.WriteLine(c.Info);

        Console.WriteLine("\nAll Dogs:");

        foreach (var d in db.Dogs)
            Console.WriteLine(d.Info);
    }
}