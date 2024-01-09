using ProbeLibraryJ2PMp2;

namespace ProbeAppJ2PMp2
{
    internal class Program
    {
        public static Random RAND = new();
        static void Main(string[] args)
        {
            ClassUsingHandler handler = new();
            handler.IntHandler += TestMethod;

            Console.WriteLine(handler.callHandler());
        }

        static int TestMethod() => RAND.Next(10, 100);
    }
}