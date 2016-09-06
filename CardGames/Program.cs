using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {            
            War WarGame = new War();
            BlackJack BlackJackGame = new BlackJack();

            int choice = 0;

            do
            {
                Console.WriteLine("Hello user... Would you like to play War or Blackjack today?");
                Console.WriteLine("(1) War");
                Console.WriteLine("(2) Blackjack");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch { }

                if (choice < 1 || choice > 2)
                {
                    Console.WriteLine("Try again...");
                    Console.ReadLine();
                }
                Console.Clear();
            } while (choice != 1 && choice != 2);

            switch (choice)
            {
                case 1:
                    WarGame.StartWar();
                    break;
                case 2:
                    BlackJackGame.StartBlackjack();
                    break;
                default:
                    break;
            }
            Console.ReadLine();
            choice = 0;
        } 
    }
}
