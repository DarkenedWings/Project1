﻿using System;
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

            deck.MakeDeck();
            deck.Shuffle();
            deck.Show();
            Console.ReadLine();
            
        }
    }
}
