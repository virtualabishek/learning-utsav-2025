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

    }

}