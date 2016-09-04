using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class War
    {
        Deck deck = new Deck();



        public void DealCards()
        {

        }

        public void TurnCards()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, Console.WindowHeight / 4);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("  ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, Console.WindowHeight / 4 + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("7" + (char)3);

            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, (Console.WindowHeight / 4) * 3);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("  ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, (Console.WindowHeight / 4) * 3 - 1);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("7" + (char)6);
        }
    }
}
