using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic a = new Logic();
            Boolean b = true;
            while (b == true)
            {
                a.startGame();
                Console.WriteLine("Want to play again? (Y/N)");
                String c;
                c = Console.ReadLine();
                c = c.Trim().ToUpper();
                if (c == "N")
                {
                    b = false;
                }
            }

        }
    }
}
