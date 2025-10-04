using LearningUtsav;

namespace LearningUtsav
{
    public class HelpAttribute : Attribute {
    public string HelpText { get; }
    public string Topic { get; set; }

    public HelpAttribute(string helpText)
    {
        HelpText = helpText ?? throw new ArgumentNullException(nameof(helpText));
    }
}

    public class Calculator
    {
        [Help("Add two numbers: result = a + b")]
        public int Add(int a, int b)
        {
            return a + b;
        }
        [Help("Multiply: result = a * b", Topic = "Math")]
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}