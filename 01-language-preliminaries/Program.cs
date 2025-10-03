using System.Collections;
using System.Net;
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
        //  ============ Delegate =============
        SampleDelegate SampleObject1 = new SampleDelegate();

        SampleDelegate.Addnum del_obj1 = new SampleDelegate.Addnum(SampleObject1.sum);
        SampleDelegate.Subnum del_obj2 = new SampleDelegate.Subnum(SampleObject1.subtract);

        del_obj1(100, 40);
        del_obj2(100, 60);

        // ================ EVENT =============
        Console.WriteLine("================= EVENT =============");
        Publisher pub = new Publisher();
        Logger logger = new Logger();
        Emailer emailer = new Emailer();
        pub.OnAlert -= logger.Log;
        pub.OnAlert += emailer.SendEmail;
        pub.RaiseAlert("Student enrolled!");

        // ============= Collection ===================
        Console.WriteLine("============= Collection ===================");
        // Sample as the array for storing
        ArrayList al = new ArrayList();
        Console.WriteLine("Adding some numbers: ");
        al.Add(23);
        al.Add(24);
        al.Add(45);
        al.Add(35);

        Console.WriteLine("Capacity: {0}", al.Capacity);
        Console.WriteLine("Count: {0}", al.Count);
        foreach (int i in al)
        {
            Console.WriteLine(i + "");
        }
        Console.WriteLine();
        Hashtable ht = new Hashtable();
        ht.Add("ora", "Oracle");
        ht.Add("ncc", "Net Centric");
        ht.Add("rm", "Research Methodology");
        foreach (DictionaryEntry d in ht)
        {
            Console.WriteLine(d.Key + " " + d.Value);
        }

        // =========== Generics ==============
        Console.WriteLine("=========== Generics ==============");
        List<int> lst = new List<int>();
        lst.Add(1);
        lst.Add(2);
        lst.Add(22);
        List<string> lst2 = new List<string>();
        lst2.Add("Abi");
        lst2.Add("Abinash");
        lst2.Add("Bhati");
        Console.WriteLine("List 1 with integer: ");
        foreach (var i in lst)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("List 2 with String: ");
        foreach (var n in lst2)
        {
            Console.WriteLine(n);
        }
    }

}