namespace LearningUtsav
{
    public interface IDrawable
    {
        void Draw();
        string Description { get; }
    }

    public class Cir : IDrawable
{
    public double Radius { get; set; }

    public void Draw()
    {
        Console.WriteLine($"Drawing circle with radius {Radius}");
    }

    public string Description => $"Circle area = {Math.PI * Radius * Radius:F2}";
}
    public class Button : IDrawable 
{
    public string Text { get; set; }

    public void Draw()
    {
        Console.WriteLine($"Rendering button: {Text}");
    }

    public string Description => $"Button: '{Text}'";
}
}