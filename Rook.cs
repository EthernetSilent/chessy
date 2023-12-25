using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class Rook : Piece
    {
        public Rook()
        {
            Value = 5;
            PieceName = "Rook";
        }
        //getmoves will be a linklist
        public override List<Move> GetMoves(Board brd)
        {
            List<Move> movelist = new List<Move>();
            Move mv = new Move();
            mv.movedPiece = this;
            int increment = 1;
            // up:
            // start with one square up until border reached
            mv.Row = this.Row + increment;
            mv.Column = this.Col;

            while(checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null || brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    movelist.Add(mv);
                    break;
                } else
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
            MessageBox.Show($"Column {mv.Column}");
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
                    mv.Column = this.Col + (increment * 1);
                }
            }
            return movelist;
        }
    }
}
