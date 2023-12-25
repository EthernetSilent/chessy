using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class QueenR : Piece
    {
        protected List<Move> movelist;

        public QueenR()
        {
            Value = 9;
            PieceName = "Queen";
        }

        public List<Move> GetMoves(Board brd)
        {
            movelist = new List<Move>();
            up(brd, 1);
            down(brd, 1);
            left(brd, 1);
            right(brd, 1);
            upRight(brd, 1);
            upLeft(brd, 1);
            downRight(brd, 1);
            downLeft(brd, 1);
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
                else if(brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
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

        public void upRight(Board brd, int dist)
        {
            Move mv = new Move()
            {
                Row = this.Row + dist,
                Column = this.Col + dist
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    upRight(brd, dist + 1);
                }
                else
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                }
            }
        }

        public void upLeft(Board brd, int dist)
        {
            Move mv = new Move()
            {
                Row = this.Row + dist,
                Column = this.Col - dist
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    upLeft(brd, dist + 1); // callback because you might be able to move forward
                }
                else
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv); // do not callback as you stop when 
                }
            }
        }
        public void downRight(Board brd, int dist)
        {
            Move mv = new Move()
            {
                Row = this.Row - dist,
                Column = this.Col + dist
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    downRight(brd, dist + 1);
                }
                else
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                }
            }
        }

        public void downLeft(Board brd, int dist)
        {
            Move mv = new Move()
            {
                Row = this.Row - dist,
                Column = this.Col - dist
            };

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    downLeft(brd, dist + 1);
                }
                else
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                }
            }
        }
    }
}
