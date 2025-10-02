namespace LearningUtsav
{
    public abstract class Ani
    {
        public string Name { get; set; }
        protected Ani(string name)
        {
            Name = name;
        }
        public abstract void Eat();
        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }
    }

    public class Tiger : Ani
    {
        public Tiger(string name) : base(name) { }
        public override void Eat()
        {
            Console.WriteLine($"{Name} eats Tiger food.");
        }
    }


    public class Wolf : Ani
    {
        public Wolf(string name) : base(name) { }

        public override void Eat()
        {
            Console.WriteLine($"{Name} eats fancy Wolf food.");
        }
    }


    public sealed class PetRock : Ani
    {
        public PetRock(string name) : base(name) { }
        public override void Eat()
        {
            Console.WriteLine($"{Name} does nothings it a rock");
        }
    }
}

