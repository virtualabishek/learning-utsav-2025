using System.Text;
using LearningUtsav;

class Program
{
    static void Main()
    {
        // // For Method Overloading
        Console.WriteLine("Method Overloading");

        Animal myPet1 = new Dog();
        Animal myPet2 = new Cat();

        myPet1.Speak();
        myPet2.Speak();


        Dog myDog = new Dog();
        myDog.Speak();

        // Console.WriteLine("=======================");
        Console.WriteLine("Method Hiding");

        Bird myBird1 = new Duck();
        myBird1.Sound();

        Duck myDuck = new Duck();
        myDuck.Sound();

        Crow myCrow = new Crow();
        myCrow.Sound();

        // Console.WriteLine("=======================");
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
        //  ====== Properties =======
        Student s1 = new Student();
        Student s2 = new Student("Abi", 2);
        Student s3 = new Student(s2);
        Student s = new Student();
        s.Id = 1;
        s.Name = "Abi";
        // ========= Arrays & Strings =======
        int[] grades = new int[3];
        grades[0] = 87;
        grades[1] = 92;
        grades[2] = 78;

        string[] names = { "Abi", "Bhagawati", "Abinash" };
        foreach (int g in grades)
        {
            Console.WriteLine(g);
        }

        string fullName = "Abishek Neupane";
        string upper = fullName.ToUpper();
        string greet = $"Namasteeem, {fullName}";

        StringBuilder sb = new StringBuilder();
        sb.Append("Grade: ").Append(grades[0]).AppendLine();
        Console.WriteLine(sb.ToString());
        // ====== Indexers ================
        Indexes o = new Indexes();
        o[0] = "C";
        o[1] = "C++";
        o[2] = "C#";
        Console.WriteLine("First value: " + o[0]);
        Console.WriteLine("Second value: " + o[1]);
        Console.WriteLine("Third value: " + o[2]);
        // ======== Inheritence with base ===========

        Employee e = new Employee("Abi", 20022);
        e.Greet();
        // ====== Polymorephism========
        Console.WriteLine("====== Polymorephism========");
        List<Shape> shapes = new List<Shape>
        {
            new Circle {Color = "Red", Radius = 5},
            new Rectangle {Color = "Blue", Width = 4, Height = 6}
        };

        Console.WriteLine("Drawing all shapes.");
        double totalArea = 0;
        foreach (Shape shape in shapes)
        {
            shape.Draw();
            totalArea += shape.CalculateArea();
        }
        Console.WriteLine($"Total area: {totalArea:F2}");
        // ===== Abstract Class ===========
        Console.WriteLine(" ===== Abstract Class ===========");
        List<Ani> shelter = new List<Ani> { new Tiger("DANGER"), new Wolf("Wwwww") };
        foreach (Ani pet in shelter)
        {
            pet.Eat();
            pet.Sleep();
        }

        // ===== Sealed Class ===========
        Console.WriteLine(" ===== Sealed Class ===========");
        PetRock rock = new PetRock("Fred");
        rock.Sleep();

        // ========== interfacce =========
        Console.WriteLine("========== interfacce =========");
        List<IDrawable> drawables = new List<IDrawable>
        {
            new Cir { Radius = 5 },
            new Button { Text = "Click Me" }
        };

        foreach (IDrawable item in drawables)
        {
            item.Draw();  // Polymorphism: Calls actual impl
            Console.WriteLine(item.Description);
        }








    }

}