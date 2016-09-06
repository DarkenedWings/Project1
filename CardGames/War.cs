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
        Human Player1 = new Human();
        Computer CPU = new Computer();

        int CardCount = 0;
        int GameSpeed = 0;
        int WarTime = 0;
        int WarCardPlace = 2;

        public void StartWar()
        {
            Console.Clear();
            deck.MakeDeck();
            deck.Shuffle();
            DealCards();
            //CPU.TestingShow();


            //Set the game speed
            do
            {
                Console.Clear();
                Console.WriteLine("Would you like the fast or slow speed?");
                Console.WriteLine("(1) Fast");
                Console.WriteLine("(2) Slow");
                try
                {
                    GameSpeed = int.Parse(Console.ReadLine());
                }
                catch
                {
                }
                if (GameSpeed < 1 || GameSpeed > 2)
                {
                    Console.WriteLine("Try again...");
                    Console.ReadLine();
                }
            } while (GameSpeed != 1 && GameSpeed != 2);

            PlayGame();
            
        }

        public void DealCards()
        {
            for (int i = 0; i < 52; i++)
            {
                if (CardCount % 2 == 0)
                    Player1.AddCardToHand(deck.GetCard(i));
                else
                    CPU.AddCardToHand(deck.GetCard(i));
                CardCount++;
            }
        }

        public void PlayGame()
        {
            do
            {
                Console.Clear();

                //Have current hand sizes displayed
                Console.SetCursorPosition(0, 0);
                Console.Write("Your current deck size: " + Player1.GetHandSize());

                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("CPU deck size: " + CPU.GetHandSize());

                //Display the cards
                TurnCards(Player1.GetCardItself(0), CPU.GetCardItself(0));

                //Comparing card values
                if (Player1.GetCardValue(0) == 1 && CPU.GetCardValue(0) != 1)
                {
                    Player1.AddCardToHand(CPU.GetCardItself(0));
                    Player1.AddCardToHand(Player1.GetCardItself(0));
                    Player1.LoseCards();
                    CPU.LoseCards();
                }
                else if (CPU.GetCardValue(0) == 1 && Player1.GetCardValue(0) != 1)
                {
                    CPU.AddCardToHand(Player1.GetCardItself(0));
                    CPU.AddCardToHand(CPU.GetCardItself(0));
                    CPU.LoseCards();
                    Player1.LoseCards();
                }
                else if (Player1.GetCardValue(0) == 2 || CPU.GetCardValue(0) == 2)
                {
                    string TwoWar = "A two was thrown. This means WAR!!!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(Console.WindowWidth / 2 - (TwoWar.Length / 2), Console.WindowHeight / 2);
                    Console.WriteLine(TwoWar);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    CardsAtWar();
                }
                else if (Player1.GetCardValue(0) > CPU.GetCardValue(0))
                {
                    Player1.AddCardToHand(CPU.GetCardItself(0));
                    Player1.AddCardToHand(Player1.GetCardItself(0));
                    Player1.LoseCards();
                    CPU.LoseCards();
                }
                else if (CPU.GetCardValue(0) > Player1.GetCardValue(0))
                {
                    CPU.AddCardToHand(Player1.GetCardItself(0));
                    CPU.AddCardToHand(CPU.GetCardItself(0));
                    CPU.LoseCards();
                    Player1.LoseCards();
                }
                else if (Player1.GetCardValue(0) == CPU.GetCardValue(0))
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WAR!!!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    CardsAtWar();
                }
                WarCardPlace = 2;

                WarTime = 0;

                if (GameSpeed == 2)
                    Console.ReadLine();
                else
                    System.Threading.Thread.Sleep(50);

            } while (Player1.GetHandSize() > 0 && CPU.GetHandSize() > 0);

            if (Player1.GetHandSize() <= 0)
            {
                YouLose();
            }
            else if (CPU.GetHandSize() <= 0)
            {
                YouWin();
            }

        }

        private static void YouLose()
        {
            string lose = "You Lose...";
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - lose.Length) / 2, Console.WindowHeight / 2);
            Console.Write(lose);
            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void YouWin()
        {
            string victory = "You Win!!!";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - victory.Length) / 2, Console.WindowHeight / 2);
            Console.Write(victory);
            Console.ReadLine();
            Environment.Exit(0);
        }

        public void TurnCards(Cards P1, Cards Com)
        {
            Console.SetCursorPosition(WarCardPlace, Console.WindowHeight / 4 - (WarCardPlace % 4));
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("   ");
            Console.SetCursorPosition(WarCardPlace , Console.WindowHeight / 4 + 1 - (WarCardPlace % 4));
            if (P1.GetSuit() == (char)3 || P1.GetSuit() == (char)4)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Black;
            if (P1.GetVal() == 1)
                Console.Write('A' + " " + P1.GetSuit());
            else if (P1.GetVal() < 10 && P1.GetVal() > 1)
                Console.Write(P1.GetVal() + " " + P1.GetSuit());
            else if (P1.GetVal() == 10)
                Console.Write("10" + P1.GetSuit());
            else if (P1.GetVal() == 11)
                Console.Write('J' + " " + P1.GetSuit());
            else if (P1.GetVal() == 12)
                Console.Write('Q' + " " + P1.GetSuit());
            else if (P1.GetVal() == 13)
                Console.Write('K' + " " + P1.GetSuit());

            Console.SetCursorPosition(WarCardPlace, (Console.WindowHeight / 4) * 3 + (WarCardPlace % 4));
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("   ");
            Console.SetCursorPosition(WarCardPlace, (Console.WindowHeight / 4) * 3 - 1 + (WarCardPlace % 4));
            if (Com.GetSuit() == 3 || Com.GetSuit() == 4)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Black;

            if (Com.GetVal() == 1)
                Console.Write('A' + " " + Com.GetSuit());
            else if (Com.GetVal() < 10 && Com.GetVal() > 1)
                Console.Write(Com.GetVal() + " " + Com.GetSuit());
            else if (Com.GetVal() == 10)
                Console.Write("10" + Com.GetSuit());
            else if (Com.GetVal() == 11)
                Console.Write('J' + " " + Com.GetSuit());
            else if (Com.GetVal() == 12)
                Console.Write('Q' + " " + Com.GetSuit());
            else if (Com.GetVal() == 13)
                Console.Write('K' + " " + Com.GetSuit());

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void CardsAtWar()
        {
            WarTime += 4;
            Console.ReadLine();
            for (int i = WarTime - 3; i < WarTime + 1; i++)
            {
                if (Player1.GetHandSize() <= i)
                    YouLose();
                else if (CPU.GetHandSize() <= i)
                    YouWin();
                WarCardPlace += 2;
                TurnCards(Player1.GetCardItself(i), CPU.GetCardItself(i));
                Console.ReadLine();
            }
            if (Player1.GetCardValue(WarTime) == 2 || CPU.GetCardValue(WarTime) == 2)
                CardsAtWar();
            else if (Player1.GetCardValue(WarTime) > CPU.GetCardValue(WarTime))
            {
                Player1.AddCardToHand(CPU.GetCardItself(0));
                CPU.LoseCards();
                Player1.AddCardToHand(CPU.GetCardItself(0));
                CPU.LoseCards();
                Player1.AddCardToHand(CPU.GetCardItself(0));
                CPU.LoseCards();
                Player1.AddCardToHand(CPU.GetCardItself(0));
                CPU.LoseCards();
                Player1.AddCardToHand(Player1.GetCardItself(0));
                Player1.LoseCards();

            }
            else if (CPU.GetCardValue(WarTime) > Player1.GetCardValue(WarTime))
            {
                CPU.AddCardToHand(Player1.GetCardItself(0));
                Player1.LoseCards();
                CPU.AddCardToHand(Player1.GetCardItself(0));
                Player1.LoseCards();
                CPU.AddCardToHand(Player1.GetCardItself(0));
                Player1.LoseCards();
                CPU.AddCardToHand(Player1.GetCardItself(0));
                Player1.LoseCards();
                CPU.AddCardToHand(CPU.GetCardItself(0));
                CPU.LoseCards();
            }
            else if (Player1.GetCardValue(WarTime) == CPU.GetCardValue(WarTime))
                CardsAtWar();
        }
    }
}
