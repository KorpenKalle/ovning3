using System;
using System.Collections.Generic;

// 3.1 Inkapsling

public class Person
{
    private int age;
    private string fName;
    private string lName;
    private double height;
    private double weight;

    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Aldern maste vara storre an 0.");
            }
            age = value;
        }
    }

    public string FName
    {
        get { return fName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value.Length > 10)
            {
                throw new ArgumentException("Fornamnet maste vara mellan 2 och 10 tecken.");
            }
            fName = value;
        }
    }

    public string LName
    {
        get { return lName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 15)
            {
                throw new ArgumentException("Efternamnet maste vara mellan 3 och 15 tecken.");
            }
            lName = value;
        }
    }

    public double Height { get => height; set => height = value; }
    public double Weight { get => weight; set => weight = value; }
}

public class PersonHandler
{
    public void SetAge(Person pers, int age)
    {
        pers.Age = age;
    }

    public Person CreatePerson(int age, string fname, string lname, double height, double weight)
    {
        Person person = new Person
        {
            Age = age,
            FName = fname,
            LName = lname,
            Height = height,
            Weight = weight
        };
        return person;
    }

    // Exempelmetoder for att hantera Person-objekt
    public void UpdatePersonHeight(Person person, double height)
    {
        person.Height = height;
    }

    public void UpdatePersonWeight(Person person, double weight)
    {
        person.Weight = weight;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            PersonHandler handler = new PersonHandler();
            Person person1 = handler.CreatePerson(25, "John", "Doe", 180.0, 75.0);
            Console.WriteLine($"Person: {person1.FName} {person1.LName}, Age: {person1.Age}, Height: {person1.Height}, Weight: {person1.Weight}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Fel: {ex.Message}");
        }

        // 3.2 Polymorfism

        List<UserError> errors = new List<UserError>
        {
            new NumericInputError(),
            new TextInputError()
        };

        foreach (var error in errors)
        {
            Console.WriteLine(error.UEMessage());
        }
    }
}

// 3.2 Polymorfism

public abstract class UserError
{
    public abstract string UEMessage();
}

public class NumericInputError : UserError
{
    public override string UEMessage() => "You tried to use a numeric input in a text only field. This fired an error!";
}

public class TextInputError : UserError
{
    public override string UEMessage() => "You tried to use a text input in a numeric only field. This fired an error!";
}

// 3.3 Arv

public abstract class Animal
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }

    public Animal(string name, double weight, int age)
    {
        Name = name;
        Weight = weight;
        Age = age;
    }

    public abstract void DoSound();

    public virtual string Stats()
    {
        return $"Namn: {Name}, Vikt: {Weight}, Alder: {Age}";
    }
}

public class Dog : Animal
{
    public string Breed { get; set; }

    public Dog(string name, double weight, int age, string breed) : base(name, weight, age)
    {
        Breed = breed;
    }

    public override void DoSound() => Console.WriteLine("Voff!");

    public override string Stats() => base.Stats() + $", Ras: {Breed}";
}

public class Cat : Animal
{
    public Cat(string name, double weight, int age) : base(name, weight, age) { }

    public override void DoSound() => Console.WriteLine("Mjau!");
}

// (Fortsatt med ovriga djur samt implementation av Bird, Horse, etc.)

// 3.4 Mer polymorfism

class ProgramAnimals
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog("Rufus", 20.5, 3, "Labrador"),
            // Lagg till andra djur har
        };

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.Stats());
            animal.DoSound();
        }

        // Forsok inte att lagga till en hast i djurlistan
        // List<Dog> dogs = new List<Dog>(); // Hundlista
        // dogs.Add(new Horse("Spirit", 300, 5)); // Detta skulle ge ett kompileringfel.

        // For att alla klasser ska lagras tillsammans, maste listan vara av typen Animal.
    }
}

