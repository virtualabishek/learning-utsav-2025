// Method Overloading


public class Animal
{
    public virtual void Speak()
    // virtual can be overridden so it is used.
    {
        Console.WriteLine("The animal makes a sound");
    }
}


public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Woof: The dog barks.");
    }
}





public class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Meow! The cat do meows.");
    }
}

// Method Hididng
public class Bird
{
    public void Sound()
    {
        Console.WriteLine("The birds makes soubd");
    }
}


public class Duck : Bird
{
    public new void Sound()
    {
        Console.WriteLine("Quack! Quack! The duck makes sound");
    }
}


public class Crow : Bird
{
    public new void Sound()
    {
        Console.WriteLine("Kwa Kwa! I do kwa kwa.");
    }
}

// Real world Example

public class Vechile
{
    public string Brand { get; set; }
    // Overridable: polymorphism start
    public virtual void StartEngine()
    {
        Console.WriteLine($"{Brand} vechile starts with general engine.");
    }
    // hidable
    public void GetInfo()
    {
        Console.WriteLine($"Basic Vechile info: unknown model.");
    }
}


public class Car : Vechile
{
    public Car(string brand) { Brand = brand; }
    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} car roars to life: VOOOOOOM! VOOOOOM");
    }

    public new void GetInfo()
    {
        Console.WriteLine($"{Brand} car: 4 wheels, comfortable seats.");
    }
}


public class Motorcycle : Vechile
{
    public Motorcycle(string brand) { Brand = brand; }

    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} motorcycle revs up: BRRRAP!");
    }

}


class Program
{
    static void Main()
    {
        // For Method Overloading
        Console.WriteLine("Method Overloading");

        Animal myPet1 = new Dog();
        Animal myPet2 = new Cat();

        myPet1.Speak();
        myPet2.Speak();


        Dog myDog = new Dog();
        myDog.Speak();

        Console.WriteLine("=======================");
        Console.WriteLine("Method Hiding");

        Bird myBird1 = new Duck();
        myBird1.Sound();

        Duck myDuck = new Duck();
        myDuck.Sound();

        Crow myCrow = new Crow();
        myCrow.Sound();

        Console.WriteLine("=======================");
        Console.WriteLine("Real Example");
        List<Vechile> fleet = new List<Vechile>
        {
            new Car("Toyato"),
            new Motorcycle("Yamaha"),
            new Car("BMD")
        };
        Console.WriteLine("Starting fleet engines");
        foreach (var vechile in fleet)
        {
            vechile.StartEngine();
        }
        Console.WriteLine("Hiding Example");
        Vechile hiddenCar = new Car("Tesla");
        // here ref is vechile
        hiddenCar.GetInfo();
        Car directCar = new Car("BMW");
        directCar.GetInfo();
        Console.WriteLine("\n===  Motorcycle ===");
        Motorcycle bike = new Motorcycle("Yamaha");
        bike.GetInfo();

    }

}