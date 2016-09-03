using System;

namespace CardGames
{
    internal class Cards
    {
        int Value;
        char suit;

        public Cards()
        {
            Value = 0;
            suit = ' ';
        }

        public Cards(int Val, char type)
        {
            Value = Val;
            suit = type;
        }
        
        public int GetVal()
        {
            return Value;
        }
    }
}