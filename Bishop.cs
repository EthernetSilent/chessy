using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace chessy
{
    internal class Bishop : Piece
    {
        public Bishop()
        {
            Value = 3;
            PieceName = "Bishop";
        }
        public override List<Move> GetMoves(Board brd)
        {
            List<Move> movelist = new List<Move>();
            // upright:
            // start with one upright then increment until border reached
            int increment = 1;
            Move mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col + increment; // right
            mv.Row = this.Row + increment; // up
            mv.Type = "Move";

            while(checkBoundary(mv))
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    break;
                } else
                {
                    movelist.Add(mv);

                    increment += 1;
                    mv.Column = this.Col + increment; // right
                    mv.Row = this.Row + increment; // up
                }
            }

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col - increment; // left
            mv.Row = this.Row + increment; // up
            mv.Type = "Move";

            while (checkBoundary(mv))
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    break;
                }
                else
                {
                    movelist.Add(mv);

                    increment += 1;
                    mv.Column = this.Col - increment; // left
                    mv.Row = this.Row + increment; // up
                }
            }

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col - increment; // left
            mv.Row = this.Row - increment; // down
            mv.Type = "Move";

            while (checkBoundary(mv))
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    break;
                }
                else
                {
                    movelist.Add(mv);

                    increment += 1;
                    mv.Column = this.Col - increment; // left
                    mv.Row = this.Row - increment; // down
                }
            }

            mv = new Move();
            mv.movedPiece = this;
            mv.Column = this.Col + increment; // right
            mv.Row = this.Row - increment; // down
            mv.Type = "Move";

            while (checkBoundary(mv))
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null)
                {
                    mv.Type = "Capture";
                    mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                    break;
                }
                else
                {
                    movelist.Add(mv);

                    increment += 1;
                    mv.Column = this.Col + increment; // right
                    mv.Row = this.Row - increment; // down
                }
            }
            return movelist;
        }

        
    }
}
