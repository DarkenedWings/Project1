using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Human : Player
    {
        List<Cards> Hands = new List<Cards>();
        protected int HandSize;

        public void Draw()
        {

        }
    }
}
