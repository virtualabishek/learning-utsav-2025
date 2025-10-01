namespace LearningUtsav
{
    public class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
            Console.WriteLine($"Person Created: {Name}");
        }
        public virtual void Greet()
        {
            Console.WriteLine($"Hi, I'm {Name}");
        }
    }
    public class Employee : Person
    {
        public int Employelevel;
        public Employee(string name, int level) : base(name)
        {
            Employelevel = level;
            Console.WriteLine("Student details set.");
        }
        public override void Greet()
    {
        base.Greet();  
        Console.WriteLine($"I'm a {Employelevel}th grader.");
    }
    }
    

}