using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Deck
    {
        Random RNG = new Random();        
              
        List<Cards> deck = new List<Cards>();
        Cards tmp = new Cards();
        
        int randX;

        public void MakeDeck()
        {
            
            for (int i = 0; i < 13; i++)
                deck.Add(new Cards((i % 13 + 1), (char)3));

            for (int i = 13; i < 26; i++)
                deck.Add(new Cards((i % 13 + 1), (char)4));

            for (int i = 26; i < 39; i++)
                deck.Add(new Cards((i % 13 + 1), (char)5));

            for (int i = 39; i < 52; i++)
                deck.Add(new Cards((i % 13 + 1), (char)6));
        }

        public void Shuffle()
        {
            for (int i = 0; i < 13; i++)
            {
                randX = RNG.Next(0, 52);
                tmp = deck[i];
                deck[i] = deck[randX];
                deck[randX] = tmp;
            }
        }

        public void Show()
        {
            for (int i = 0; i < 52; i++)
                Console.Write(deck[i].GetVal() + " ");
        }
        
        public Cards GetCard(int num)
        {
            return deck[num];
        }

        public void RemoveCard()
        {
            deck.Remove(deck[0]);
        }

        public void ResetDeck()
        {
            for (int i = deck.Count - 1; i > 0; i--)
            {
                deck.RemoveAt(i);
            }
        }
    }
}
