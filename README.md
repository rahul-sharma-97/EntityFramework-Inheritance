By default it implements **Table Per Hierarichy** Inheritance.

In order to implement **Table Per Type** uncomment below lines from AnimalContext.cs

modelBuilder.Entity<Dog>().ToTable("Dogs");
modelBuilder.Entity<Cat>().ToTable("Cats");
