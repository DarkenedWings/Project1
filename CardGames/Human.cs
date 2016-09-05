using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Human : Player
    {
        List<Cards> PlayerHand = new List<Cards>();

        public void Draw()
        {

        }

        public override void AddCardToHand(Cards card)
        {
            PlayerHand.Add(card);
            HandSize++;
        }

        public override void LoseCards()
        {
            PlayerHand.RemoveAt(0);
            HandSize --;

        }

        public override int GetHandSize()
        {
            return HandSize;
        }

        public override int GetCardValue(int i)
        {
            return PlayerHand[i].GetVal();
        }

        public override char GetCardSuit()
        {
            return PlayerHand[0].GetSuit();
        }

        public override Cards GetCardItself()
        {
            return PlayerHand[0];
        }

        //public void TestingShow()
        //{
        //    for (int i = 0; i < HandSize; i++)
        //        Console.Write(PlayerHand[i].GetVal() + " ");
        //    Console.WriteLine();
        //    Console.WriteLine(HandSize);
        //    Console.ReadLine();
        //}
    }
}
