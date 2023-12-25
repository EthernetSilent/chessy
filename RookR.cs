using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class RookR : Piece
    {
        protected List<Move> movelist;

        

        public RookR()
        {
            Value = 5;
            PieceName = "Rook";
        }
        public List<Move> GetMoves(Board brd)
        {
            movelist = new List<Move>();
            up(brd, 1);
            down(brd, 1);
            left(brd, 1);
            right(brd, 1);
            return movelist;
        }
        public void up(Board brd, int dist)
        {
            Move mv = new Move()
            {
                Row = this.Row + dist,
                Column = this.Col
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    up(brd, dist + 1);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                }
            }
        }

        public void down(Board brd, int dist)
        {
            Move mv = new Move()
            {
                Row = this.Row - dist,
                Column = this.Col
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    down(brd, dist + 1);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                }
            }
        }

        public void left(Board brd, int dist)
        {
            Move mv = new Move()
            {
                Row = this.Row,
                Column = this.Col - 1
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    left(brd, dist + 1);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                }
            }
        }

        public void right(Board brd, int dist)
        {
            Move mv = new Move()
            {
                Row = this.Row,
                Column = this.Col + dist
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    right(brd, dist + 1);
                }
                else if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                }
            }
        }
    }
}
