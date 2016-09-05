using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Player
    {
        List<Cards> Hand = new List<Cards>();
        protected int HandSize = 0;

        public Player()
        {

        }

        virtual public void AddCardToHand(Cards card)
        {
            Hand.Add(card);
        }

        virtual public void LoseCards()
        {
            
        }

        virtual public int GetHandSize()
        {
            return HandSize;
        }

        virtual public int GetCardValue(int i)
        {
            return Hand[i].GetVal();
        }

        virtual public char GetCardSuit()
        {
            return Hand[0].GetSuit();
        }

        virtual public Cards GetCardItself()
        {
            return Hand[0];

        }
    }
}
