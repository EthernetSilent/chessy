using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    public class Game
    {
        private List<Move> Moves;
        private string PGN;
        private Board brd;
        public Player playerWhite = new Player()
        {
            Colour = "White"
        };

        public Player playerBlack = new Player()
        {
            Colour = "Black"
        };
        enum Outcome
        {
            BlackWin = 0,
            Draw = 1,
            WhiteWin = 2
        }
        public Game()
        {
            
        }
        public void AddMove(Move mv)
        {
            Moves.Add(mv);
        }
    }
}
