interface ICalculator
{
    void GetData(double a, double b);
    double SumData();
    double MultiplyData();
}



class Calculator : ICalculator
{
    public double a;
    public double b;
    public void GetData(double a, double b)
    {
        this.a = a;
        this.b = b;
    }
    public double SumData()
    {
        return a + b;
    }
    public double MultiplyData ()
    {
        return a * b;
    }
}


class Cons
{
    // constructor and constructor name should be same.
    private int a, b;
    public Cons(int a, int b)
    {
        this.a = a;
        this.b = b;

    }

    public void Display()
    {
        Console.WriteLine($"This is sum: {this.a + this.b}");
    }




    class Multiply
    {
        // Construcror Overloading
        public Multiply(int a, int b)
        {
            Console.WriteLine($"The mul is: {a * b}");
        }
        public Multiply(int a, int b, int c)
        {
            Console.WriteLine($"The mul is: {a * b * c}");
        }
        public Multiply(int a, double b)
        {
            Console.WriteLine($"The mul is: {a * b}");

        }

    }

    class Stat
    {
        public Stat()
        {
            Console.WriteLine("I am not static. i will called when you call me");
        }

        static Stat()
        {
            Console.WriteLine("I will call just once.");
        }
        ~Stat()
        {
            Console.WriteLine("I am distruct");
        }

    }
    // Property (automatic property)
    class Proper
    {
        private int x;
        public int y { get; set; }
        public void SetX(int x)
        {
            this.x = x;
        }

        public int GetX()
        {
            return this.x;
        }
        public int SumI()
        {
            int addi = x + y;
            return addi;
        }
    }
    // Indexers
    class IndexClass
    {
        private string[] cities = new string[2];
        public string this[int i]
        {
            get
            {
                return cities[i];
            }

            set
            {
                cities[i] = value;
            }

        }
    }


    static class StateClass
    {
        public static string firstName { get; set; }
        public static string lastName { get; set; }
        public static void Display()
        {
            Console.WriteLine($"You full name is: {firstName} {lastName}");
        }
    }

// 

    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("test...........");
            Console.WriteLine("Calling the instance constructor");
            Cons test = new Cons(2, 3);
            test.Display();
            Console.WriteLine("Calling the overoading constructor");
            new Multiply(2, 3);
            new Multiply(1, 2, 8);
            new Multiply(1, 4.5);
            new Stat();
            new Stat();
            new Stat();
            Proper p1 = new Proper();
            p1.SetX(2);
            int value = p1.GetX();
            Console.WriteLine(value);
            p1.y = 3;
            int ans = p1.SumI();
            Console.WriteLine(ans);
            IndexClass ind = new IndexClass();
            ind[0] = "Kathmandu";
            ind[1] = "Chitwan";
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(ind[i]);
            }
            StateClass.firstName = "Abi";
            StateClass.lastName = "Test";
            StateClass.Display();
            Calculator c1 = new Calculator();
            c1.GetData(1.0,2.3);
            Console.WriteLine($"{c1.SumData()} and Mul ans is {c1.MultiplyData()}");
        }


    }
}
