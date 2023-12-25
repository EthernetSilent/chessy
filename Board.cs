using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessy
{
    public class Board
    {
        public Tile[,] Tiles = new Tile[8,8];
        public Player playerwhite, playerblack;
        public Board()
        {
            playerwhite = new Player
            {
                Colour = "White"
            };
            playerblack = new Player
            {
                Colour = "Black"
            };
        }
        public Tile createTile(char col, int row)
        {
            Random rnd = new Random();
            Tile t = new Tile();
            t.column = col;
            t.row = row;
            return t;
        }
        public void createBoard()
        {
            char file;
            // assign logical tiles to tile array
            // graphical will be in form class
            for(int y = 0; y < 8; y++) // row
            {
                for(int x = 0; x < 8; x++) // column
                {
                    // logical tiles
                    file = Convert.ToChar(Convert.ToInt32(x) + 97); // e.g. 0 = a, 1 = b, 2 = c, etc
                    Tile t = createTile(file, y);
                    // assign piece to tile
                    if(y == 0 || y == 7) // 1st and 8th ranks are pieces
                    {
                        // 7 and 6 are black
                        // 1 and 0 are white
                        // 5-2 are blank

                        // piece type determined by file
                        switch(x) 
                        {
                            case 0:
                                t.TilePiece = new Rook();
                                break; 
                            case 7:
                                t.TilePiece = new Rook();
                                break; // rooks
                            case 1:
                                t.TilePiece = new Knight();
                                break;
                            case 6:
                                t.TilePiece = new Knight();
                                break; // knights
                            case 2:
                                t.TilePiece = new Bishop();
                                break;
                            case 5:
                                t.TilePiece = new Bishop();
                                break; // bishops
                            case 3:
                                t.TilePiece = new Queen();
                                break;
                            case 4:
                                t.TilePiece = new King();
                                break;
                        }
                        if (y == 0) // white
                        {
                            t.TilePiece.Colour = "White";
                        }
                        else if(y == 7)
                        {
                            t.TilePiece.Colour = "Black";
                        }
                        
                        
                    } 
                    else if(y == 1 || y == 6)
                    {
                         // 2nd and 7th ranks are all pawns
                        if (y == 1) // white
                        {
                            t.TilePiece = new Pawn("White");
                        } else if(y == 6)
                        {
                            t.TilePiece = new Pawn("Black");
                        }
                        
                    }
                    if(t.TilePiece != null)
                    {
                        t.TilePiece.Col = x;
                        t.TilePiece.Row = y;
                    }
                    Tiles[x, y] = t;
                }
            }
            
        }

        public void MakeMove(Move mv, Game game)
        {
            game.AddMove(mv);
            if(mv.movedPiece.Colour == "White")
            {
                if (mv.Type == "Capture" || mv.Type == "En Passant") // white capture
                {
                    game.playerWhite.Captured.Add(mv.capturedPiece);
                    game.playerBlack.Standing.Remove(mv.capturedPiece);
                }
                mv.movedPiece.MovePiece(mv.Column, mv.Row);
                Tiles[mv.Column, mv.Row].TilePiece = mv.movedPiece;
            } else
            {
                if (mv.Type == "Capture" || mv.Type == "En Passant") // black capture
                {
                    game.playerBlack.Captured.Add(mv.capturedPiece);
                    game.playerWhite.Standing.Remove(mv.capturedPiece);
                }
                mv.movedPiece.MovePiece(mv.Column, mv.Row);
                Tiles[mv.Column, mv.Row].TilePiece = mv.movedPiece;
            }
        }
    }
}
