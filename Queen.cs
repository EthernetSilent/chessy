using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class Queen : Piece
    {
        public Queen()
        {
            Value = 9;
            PieceName = "Queen";
        }

        public override List<Move> GetMoves(Board brd)
        {
            List<Move> movelist = new List<Move>();
            Move mv = new Move();
            int increment = 1;
            mv.movedPiece = this;
            // up:
            // start with one square up until border reached (depth first)
            mv.Row = this.Row + increment;
            mv.Column = this.Col;

            while (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null || brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    increment++;
                    mv.Row = this.Row + increment; // no column change
                }
            }

            // down:
            mv.Row = this.Row + (increment * -1); // no column change

            while (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null || brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    increment++;
                    mv.Row = this.Row + (increment * -1);
                }
            }
            increment = 1;
            // left:
            mv.Row = this.Row; // no row change this time
            mv.Column = this.Col + (increment * -1);

            while (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null || brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    increment++;
                    mv.Column = this.Col + (increment * -1);
                }
            }

            increment = 1;
            // right:

            mv.Column = this.Col + increment;
            while (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null || brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    increment++;
                    mv.Column = this.Col + (increment * -1);
                }
            }

            increment = 1;
            // upright:
            // start with one upright then increment until border reached
            mv.Row = this.Row + increment; // up one
            mv.Column = this.Col + increment; // right one
            while (checkBoundary(mv) == true) // while the move acts within the boundaries of the board
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null || brd.Tiles[mv.Column, mv.Row].TilePiece != null)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    increment++;
                    mv.Row = this.Row + increment;
                    mv.Column = this.Col + increment;
                }
            }
            increment = 1;
            // downright:
            mv.Row = this.Row + (increment * -1);
            mv.Column = this.Col + increment;
            while (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null || brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    increment++;
                    mv.Row = this.Row + (increment * -1);
                    mv.Column = this.Col + increment;
                }
            }
            increment = 1;
            // upleft:
            mv.Row = this.Row + increment; // up
            mv.Column = this.Col + (increment * -1); // left
            while (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null || brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    increment++;
                    mv.Row = this.Row + increment;
                    mv.Column = this.Col + (increment * -1);
                }
            }
            increment = 1;
            // downleft:
            mv.Row = this.Row + (increment * -1); // down
            mv.Column = this.Col + (increment * -1); // left
            while (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null || brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                }
                else
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                    increment++;
                    mv.Row = this.Row + (increment * -1);
                    mv.Column = this.Col + (increment * -1);
                }
            }
            return movelist;
        }
    }
}
