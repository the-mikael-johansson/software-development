using System;
namespace TerminalApp
{
    public interface IApp
    {
        bool Print(bool print);
    }

    public class App : IApp
    {
        public App()
        {
        }

        public bool Print(bool print)
        {
            if (print) {
                Console.WriteLine("Printing");
                return true;
            }
            return false;
        }
    }
}
