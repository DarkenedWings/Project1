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
            Deck deck = new Deck();
            Human Player1 = new Human();
            Computer CPU = new Computer();

            int choice = 0;

            deck.MakeDeck();
            deck.Shuffle();
            deck.Show();

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


            choice = 0;
        } 
    }
}
