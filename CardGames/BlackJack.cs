using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class BlackJack
    {
        Deck deck = new Deck();
        Human Player1 = new Human();
        Computer CPU = new Computer();

        int choice = 1;
        int PlayerCardPlace = 0;
        int CPUCardPlace = 0;
        int PlayerTotal = 0;
        int CPUTotal = 0;
        string HitOrStay = "Would you like to hit?";
        bool CardHidden = true;



        public void StartBlackjack()
        {
            while (choice != 3)
            {
                deck.ResetDeck();
                deck.MakeDeck();
                deck.Shuffle();
                DealCards();
                PlayerCardPlace = 0;
                CPUCardPlace = 0;
                PlayerTotal = 0;
                CPUTotal = 0;
                CardHidden = true;        

                ShowCurrentTotals();
                do
                {
                    choice = 0;
                    for (int i = 0; i < Player1.GetHandSize(); i++)
                    {
                        ShowPlayerHand(Player1.GetCardItself(i));
                        PlayerCardPlace += 1;
                    }
                    CPUHiddenCard(CPU.GetCardItself(0));
                    CPUCardPlace += 1;
                    for (int i = 1; i < CPU.GetHandSize(); i++)
                    {
                        ShowCPUHand(CPU.GetCardItself(i));
                        CPUCardPlace += 1;
                    }

                    Console.SetCursorPosition(Console.WindowWidth - HitOrStay.Length, 0);
                    Console.WriteLine(HitOrStay);
                    Console.SetCursorPosition(Console.WindowWidth - 22, 1);
                    Console.WriteLine("(1) Hit");
                    Console.SetCursorPosition(Console.WindowWidth - 22, 2);
                    Console.WriteLine("(2) Stay");
                    Console.SetCursorPosition(Console.WindowWidth - 22, 3);
                    Console.WriteLine("(3) Exit Game");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                    }

                    switch (choice)
                    {
                        case 1:
                            Player1.AddCardToHand(deck.GetCard(0));
                            deck.RemoveCard();
                            ShowCurrentTotals();
                            break;
                        case 2:
                            CPUTurn();
                            CardHidden = false;
                            PlayerCardPlace = 0;
                            CPUCardPlace = 0;
                            Console.Clear();
                            ShowCurrentTotals();
                            for (int i = 0; i < Player1.GetHandSize(); i++)
                            {
                                ShowPlayerHand(Player1.GetCardItself(i));
                                PlayerCardPlace += 1;
                            }
                            CPUCardPlace += 1;
                            for (int i = 0; i < CPU.GetHandSize(); i++)
                            {
                                ShowCPUHand(CPU.GetCardItself(i));
                                CPUCardPlace += 1;
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("See you soon!");
                            Console.ReadLine();
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }

                    PlayerCardPlace = 0;
                    CPUCardPlace = 0;
                } while (choice != 2);

                Console.ReadLine();
                CompareCards();

                //Ending resets
                PlayerCardPlace = 0;
                CPUCardPlace = 0;
                for (int i = Player1.GetHandSize(); i > 0; i--)
                    Player1.LoseCards();
                for (int i = CPU.GetHandSize(); i > 0; i--)
                    CPU.LoseCards();
                if (choice == 1)
                    StartBlackjack();
            }
        }

        public void CompareCards()
        {
            if (PlayerTotal <= 21 && PlayerTotal > CPUTotal || CPUTotal > 21)
                YouWin();
            else if (PlayerTotal == CPUTotal)
            {
                Console.Clear();
                Console.WriteLine("Tie goes to the dealer... ");
                YouLose(PlayerTotal);
            }            
            else
                YouLose(PlayerTotal);
        }

        public void YouWin()
        {
            string Winner = "You Win!!!";
            do
            {
                choice = 0;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(Console.WindowWidth / 2 - Winner.Length / 2, Console.WindowHeight / 2);
                Console.WriteLine(Winner);
                Console.SetCursorPosition(Console.WindowWidth / 2 - Winner.Length / 2, Console.WindowHeight / 2 + 1);
                Console.WriteLine("Play again?");
                Console.SetCursorPosition(Console.WindowWidth / 2 - Winner.Length / 2, Console.WindowHeight / 2 + 2);
                Console.WriteLine("(1) Yes");
                Console.SetCursorPosition(Console.WindowWidth / 2 - Winner.Length / 2, Console.WindowHeight / 2 + 3);
                Console.WriteLine("(2) No");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch 
                {
                }
                if(choice != 1 && choice != 2)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - Winner.Length / 2, Console.WindowHeight / 2 + 4);
                    Console.WriteLine("Try again...");
                    Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;

            } while (choice != 1 && choice != 2);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            switch (choice)
            {
                case 1:                    
                    break;
                case 2:                    
                    Console.WriteLine("Congrats on your win, play again soon.");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public void DealCards()
        {
            Player1.AddCardToHand(deck.GetCard(0));
            Player1.AddCardToHand(deck.GetCard(1));
            deck.RemoveCard();
            deck.RemoveCard();

            CPU.AddCardToHand(deck.GetCard(0));
            CPU.AddCardToHand(deck.GetCard(1));
            deck.RemoveCard();
            deck.RemoveCard();
        }

        public void CPUTurn()
        {
            int CPUTotal = 0;
            for (int i = 0; i < CPU.GetHandSize() ; i++)
                CPUTotal += CPU.GetCardValue(i);
            while (CPUTotal < 17)
            {
                    CPU.AddCardToHand(deck.GetCard(0));
                    CPUTotal += deck.GetCard(0).GetVal();
                    deck.RemoveCard();
            } 
        }

        public void ShowCurrentTotals()
        {
            Console.Clear();
            PlayerTotal = 0;
            CPUTotal = 0;
            for (int i = 0; i < Player1.GetHandSize(); i++)
            {
                if (Player1.GetCardValue(i) >= 10)
                    PlayerTotal += 10;
                else
                    PlayerTotal += Player1.GetCardValue(i);
            }
            if (CardHidden)
            {
                for (int i = 1; i < CPU.GetHandSize(); i++)
                {
                    if (CPU.GetCardValue(i) >= 10)
                        CPUTotal += 10;
                    else
                        CPUTotal += CPU.GetCardValue(i);
                }
            }
            else
            {
                for (int i = 0; i < CPU.GetHandSize(); i++)
                {
                    if (CPU.GetCardValue(i) >= 10)
                        CPUTotal += 10;
                    else
                        CPUTotal += CPU.GetCardValue(i);
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.Write("Your current total is ");
            if (PlayerTotal == 21)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (PlayerTotal > 21)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(PlayerTotal);
                Console.ReadLine();
                YouLose(PlayerTotal);
            }

            Console.Write(PlayerTotal);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            if (CardHidden)
                Console.Write("CPU current total is " + CPUTotal + " as far as you can see.");
            else
            {
                Console.Write("CPU total is ");
                Console.Write(CPUTotal);
            }
        }

        public void YouLose(int PlayerTotal)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            do
            {
                choice = 0;
                Console.Clear();
                Console.WriteLine("You have lost... You can quit or you can try your luck again.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("(1) Play Again");
                Console.WriteLine("(2) Exit Application");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                }

            } while (choice != 1 && choice != 2);

            switch (choice)
            {
                case 1:

                    for (int i = Player1.GetHandSize(); i > 0; i--)
                        Player1.LoseCards();
                    for (int i = CPU.GetHandSize(); i > 0; i--)
                        CPU.LoseCards();

                    StartBlackjack();
                    break;
                case 2:
                    Console.WriteLine("We are sad to see you go. Better luck next time...");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public void ShowPlayerHand(Cards P1)
        {
            Console.SetCursorPosition(PlayerCardPlace, Console.WindowHeight / 4 - (PlayerCardPlace % 4));
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("   ");
            Console.SetCursorPosition(PlayerCardPlace, Console.WindowHeight / 4 + 1 - (PlayerCardPlace % 4));
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
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        public void CPUHiddenCard(Cards Com)
        {
            Console.SetCursorPosition(CPUCardPlace, (Console.WindowHeight / 4) * 3 + (CPUCardPlace % 4));
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("???");
            Console.SetCursorPosition(CPUCardPlace, (Console.WindowHeight / 4) * 3 - 1 + (CPUCardPlace % 4));
            Console.Write("???");
        }

        public void ShowCPUHand(Cards Com)
        {
            Console.SetCursorPosition(CPUCardPlace, (Console.WindowHeight / 4) * 3 + (CPUCardPlace % 4));
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("   ");
            Console.SetCursorPosition(CPUCardPlace, (Console.WindowHeight / 4) * 3 - 1 + (CPUCardPlace % 4));
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
    }
}
