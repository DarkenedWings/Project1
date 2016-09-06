using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Computer : Player
    {
        List<Cards> ComputerHand = new List<Cards>();

        public override void AddCardToHand(Cards card)
        {
            ComputerHand.Add(card);
            HandSize++;
        }

        public override void LoseCards()
        {
            ComputerHand.RemoveAt(0);
            HandSize --;
        }

        public override int GetHandSize()
        {
            return ComputerHand.Count();
        }

        public override int GetCardValue(int i)
        {
            return ComputerHand[i].GetVal();
        }

        public override char GetCardSuit()
        {
            return ComputerHand[0].GetSuit();
        }
        public void TestingShow()
        {
            for (int i = 0; i < HandSize; i++)
                Console.Write(ComputerHand[i].GetVal() + " ");
            Console.WriteLine();
            Console.Write(HandSize);
            Console.ReadLine();
        }

        public override Cards GetCardItself(int ListSub)
        {

            return ComputerHand[ListSub];
        }
    }
}
