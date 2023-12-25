using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    internal class Pawn : Piece
    {
        // GOOGLE EN PASSANT
        // GOOGLE EN PASSANT
        // GOOGLE EN PASSANT
        // GOOGLE EN PASSANT
        // GOOGLE EN PASSANT
        private int Direction = 1;
        //private bool HasMoved = false; // EN PASSANTABLE
        public Pawn(string colour)
        {
            Value = 1;
            PieceName = "Pawn";
            Colour = colour;
            if(Colour == "White")
            {
                Direction = 1;
            } else
            {
                Direction = -1;
            }
        }

        public override List<Move> GetMoves(Board brd)
        {
            List<Move> movelist = new List<Move>();
            // EN PASSANT RIGHT
            Move mv = new Move();
            mv.movedPiece = this;
            //mv.Row = this.Row + (1 * Direction);
            //mv.Column = this.Col + 1;


            //MessageBox.Show($"{mv.Column}, {this.Row}");
            //if (checkBoundary(mv) == true)
            //{
            //    if (brd.Tiles[mv.Column, this.Row].TilePiece != null) // if there is a piece on the tile
            //    {
            //        if (brd.Tiles[mv.Column, this.Row].TilePiece.Colour != this.Colour && brd.Tiles[mv.Column, mv.Row].TilePiece.PieceName == "Pawn") // if the piece is not the same color AND a pawn
            //        {
            //            Pawn rightpawn = (Pawn)brd.Tiles[mv.Column, this.Row].TilePiece; // temporarily create a pawn object representing the actual pawn on the board
            //            if (rightpawn.HasMoved == false) // has the (temporary) pawn moved?
            //            {
            //                mv.capturedPiece = brd.Tiles[mv.Column, this.Row].TilePiece;
            //                mv.Type = "En Passant";
            //                movelist.Add(mv);
            //            }
            //        }
            //    }
            //}
            //// EN PASSANT LEFT
            //mv = new Move();
            //mv.movedPiece = this;
            //mv.Row = this.Row + (1 * Direction);
            //mv.Column = this.Col - 1;

            //if (checkBoundary(mv) == true)
            //{
            //    if (brd.Tiles[mv.Column, this.Row].TilePiece != null)
            //    {
            //        if (brd.Tiles[mv.Column, this.Row].TilePiece.Colour != this.Colour && brd.Tiles[mv.Column, mv.Row].TilePiece.PieceName == "Pawn")
            //        {
            //            Pawn leftpawn = (Pawn)brd.Tiles[mv.Column, this.Row].TilePiece;
            //            if (leftpawn.HasMoved == false)
            //            {
            //                mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
            //                mv.Type = "En Passant";
            //                movelist.Add(mv);
            //            }
            //        }
            //    }
            //}
            // moving 1 ahead

            mv = new Move();
            mv.movedPiece = this;
            mv.Row = this.Row + (1 * Direction);
            MessageBox.Show($"Colour is {Colour} and Direction is {Direction}");
            mv.Column = this.Col;

            if (checkBoundary(mv) == true) // if the move is within the boundaries of the board
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null)
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                }
            }
            // moving forward by 2

            mv = new Move();
            mv.movedPiece = this;
            mv.Row = this.Row + (2 * Direction);
            mv.Column = this.Col;

            if (checkBoundary(mv) == true)
            {
                // if the piece has not moved
                if (brd.Tiles[mv.Column, mv.Row].TilePiece == null && (this.Row == 1 || this.Row == 6))
                {
                    mv.Type = "Move";
                    movelist.Add(mv);
                }
            }
            // capturing right

            mv = new Move();
            mv.movedPiece = this;
            mv.Row = this.Row + (1 * Direction);
            mv.Column = this.Col + 1;

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null)
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        mv.Type = "Capture";
                        movelist.Add(mv);
                    }

                }
            }
            // capturing left

            mv = new Move();
            mv.movedPiece = this;
            mv.Row = this.Row + (1 * Direction);
            mv.Column = this.Col - 1;

            if (checkBoundary(mv) == true)
            {
                if (brd.Tiles[mv.Column, mv.Row].TilePiece != null)
                {
                    if (brd.Tiles[mv.Column, mv.Row].TilePiece.Colour != this.Colour)
                    {
                        mv.capturedPiece = brd.Tiles[mv.Column, mv.Row].TilePiece;
                        mv.Type = "Capture";
                        movelist.Add(mv);
                    }
                }
            }
                    
            return movelist;
        }

        
    }
}
