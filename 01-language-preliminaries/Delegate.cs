namespace LearningUtsav
{
    class SampleDelegate
    {
        public delegate void Addnum(int a, int b);
        public delegate void Subnum(int a, int b);

        public void sum(int a, int b)
        {
            Console.WriteLine("(100+40) = {0} ", a + b);
        }

        public void subtract(int a, int b)
        {
            Console.WriteLine("(100-60) = {0} ", a - b);
        }

    }
}