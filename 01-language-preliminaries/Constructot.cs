namespace LearningUtsav {
    // Constructor
    public class Student
    {
        public string Name;
        public int Age;
        // Construcror -- default
        public Student()
        {
            Name = "Unknown";
            Age = 0;
            Console.WriteLine("Default constructor called");

        }
        // parameterized constrcutor
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine($"Parameterized constructor: {Name}, {Age}");
        }
        // Copy Constructor
        public Student(Student other)
        {
            Name = other.Name;
            Age = other.Age;
            Console.WriteLine($"Copy constructor: Copied {Name}");
        }
        // Properties

        private string _address;
        private int _age;
        // auto - property
        public int Id { get; set; }
        // full property with validation
        public string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("address cant be empty");
                _address = value;

            }
        }
    }   
}