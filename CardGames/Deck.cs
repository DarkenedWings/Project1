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
              
        int[,] Cards = new int[52,4];
        int tmp;
        int randX;
        int randY;

        public void MakeDeck()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 13; i++)
                    Cards[i, j] = (i + 1);
            }
        }

        public void Shuffle()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 13; i++)
                {
                    randX = RNG.Next(0, 13);
                    randY = RNG.Next(0, 4);
                    tmp = Cards[i, j];
                    Cards[i, j] = Cards[randX, randY];
                    Cards[randX, randY] = tmp;
                }
            }
        }

        public void Show()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 13; i++)
                    Console.Write(Cards[i,j] + " ");

                Console.WriteLine();
            }
        }
    }
}
