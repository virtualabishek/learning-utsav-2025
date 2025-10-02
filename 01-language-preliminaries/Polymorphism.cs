using LearningUtsav;

namespace LearningUtsav
{
    // asbstract class
    public abstract class Shape
    {
        public string Color { get; set; }
        // abstract method must override in derived
        public abstract double CalculateArea();
        public virtual void Draw()
        {
            Console.WriteLine($"Drawing a {Color} shape");
        }
    }
}


public class Circle : Shape
{
    public double Radius { get; set; }
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
    public override void Draw()
    {
        base.Draw();
        Console.WriteLine($"Circle with radius {Radius}.");
    }
}


public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public override double CalculateArea()
    {
        return Width * Height;
    }
    public override void Draw()
    {
        base.Draw();
        Console.WriteLine($"Rectangle {Width}x{Height}.");
        
    }
}