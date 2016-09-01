using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Deck
    {
        int[] Cards = new int[52];

        public void CardGames()
        {
            for (int i = 0; i < Cards.Length/4; i++)
            {
                Cards[i] = i + 1;
            }
        }
    }
}
