using System.Drawing;
namespace chessy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Board = new Board();
            Board.createBoard();
            DrawTable();
        }
        public Board Board;
        public TableLayoutPanel BoardTable;
        public static Random rnd = new Random();
        public int tempIndex;
        //public Piece tempPiece;
        public List<Move> tempMoves;
        public Tile tempTile;
        private void DrawTable()
        {
            if (this.Controls.Contains(BoardTable))
            {
                this.Controls.Remove(BoardTable);
            }

            BoardTable = new TableLayoutPanel
            {
                ColumnCount = 8,
                RowCount = 8,
                Size = new Size(480, 480)
            };

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Board.Tiles[x, y].column = Convert.ToChar(Convert.ToInt32(x) + 97); // e.g. 0 = a, 1 = b, 2 = c, etc
                    Board.Tiles[x, y].row = y;
                    BoardTable.Controls.Add(AssignPBToTile(Board.Tiles[x, y]));

                }
            }
            BoardTable.Refresh();
            this.Controls.Add(BoardTable);
        }
        public PictureBox AssignPBToTile(Tile t)
        {
            PictureBox pb = new PictureBox();
            pb.Name = $"{t.column}{t.row + 1}"; // e.g. a4, b5, d8, etc
            pb.Width = 60;
            pb.Height = 60;
            pb.Margin = new Padding(0);
            pb.Dock = DockStyle.Fill;
            
            if (t.row % 2 == 0) // if even then both even to be lightsquare
            {
                if(t.column % 2 == 0)
                {
                    pb.BackColor = Color.PeachPuff;
                } else
                {
                    pb.BackColor = Color.Peru;
                }
            } else
            {
                if(t.column % 2 == 1)
                {
                    pb.BackColor = Color.PeachPuff;
                }
                else
                {
                    pb.BackColor = Color.Peru;
                }
            }
            // if tile present
            if(t.TilePiece == null)
            {
                pb.Click += BlankPBClicked;
            } else
            {
                switch (t.TilePiece.Colour)
                {
                    case "Black": // dark
                        switch (t.TilePiece)
                        {
                            case Pawn:
                                pb.Image = Image.FromFile("../bmp/Chess_pdt60.png");
                                break;
                            case Knight:
                                pb.Image = Image.FromFile("../bmp/Chess_ndt60.png");
                                break;
                            case Rook:
                                pb.Image = Image.FromFile("../bmp/Chess_rdt60.png");
                                break;
                            case Bishop:
                                pb.Image = Image.FromFile("../bmp/Chess_bdt60.png");
                                break;
                            case Queen:
                                pb.Image = Image.FromFile("../bmp/Chess_qdt60.png");
                                break;
                            case King:
                                pb.Image = Image.FromFile("../bmp/Chess_kdt60.png");
                                break;
                        }
                        break;
                    case "White": // light
                        switch (t.TilePiece)
                        {
                            case Pawn:
                                pb.Image = Image.FromFile("../bmp/Chess_plt60.png");
                                break;
                            case Knight:
                                pb.Image = Image.FromFile("../bmp/Chess_nlt60.png");
                                break;
                            case Rook:
                                pb.Image = Image.FromFile("../bmp/Chess_rlt60.png");
                                break;
                            case Bishop:
                                pb.Image = Image.FromFile("../bmp/Chess_blt60.png");
                                break;
                            case Queen:
                                pb.Image = Image.FromFile("../bmp/Chess_qlt60.png");
                                break;
                            case King:
                                pb.Image = Image.FromFile("../bmp/Chess_klt60.png");
                                break;
                            default:
                                pb.Image = Image.FromFile("../bmp/Chess_blt60.png");
                                break;
                        }
                        break;
                }
                pb.Click += PiecePBClicked;
            }
            
            pb.BorderStyle = BorderStyle.FixedSingle;
            return pb;
        }
        private void PiecePBClicked(object sender, EventArgs e)
        {
            DrawTable();
            tempMoves = new List<Move>();
            // picturebox indexes 0-7 are a1 to h1, 8-15 are a2 to h2, etc
            PictureBox pb = sender as PictureBox;
            //MessageBox.Show(pb.Name);
            int column = Convert.ToInt32(pb.Name[0]) - 97;
            int row = Convert.ToInt32(pb.Name[1].ToString()) - 1; // a is column 0, row is 4 in 'a4'
            int index = (row * 8) + column;
            
            
            Piece piece = Board.Tiles[column, row].TilePiece;
            MessageBox.Show($"This is a {piece.Colour} {piece.PieceName} at {pb.Name} and index {index}, row {piece.Row} and column {piece.Col}: ");
            tempTile = Board.Tiles[piece.Col, piece.Row];
            foreach(Move mv in piece.GetMoves(Board))
            {
                row = mv.Row;
                column = mv.Column;
                index = (row * 8) + column;
                
                tempMoves.Add(mv);

                MessageBox.Show($"Move at row {mv.Row}, column {mv.Column}, added to tempMoves");
                BoardTable.Controls[index].BackColor = Color.Red;
                BoardTable.Controls[index].Click -= BlankPBClicked;
                BoardTable.Controls[index].Click += HighlightedMoveClicked;
                
            }
        }

        private void BlankPBClicked(object sender, EventArgs e)
        {

            PictureBox pb = sender as PictureBox;
            int column = Convert.ToInt32(pb.Name[0]) - 97;
            int row = Convert.ToInt32(pb.Name[1].ToString()) - 1; // a is column 0, row is 4 in 'a4'
            int index = (row * 8) + column;
            MessageBox.Show($"This is a blank tile at {pb.Name} and index {index}");
        }

        private void HighlightedMoveClicked(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            //MessageBox.Show($"Highlighted move clicked at tile {pb.Name}");
            int pbColumn = Convert.ToInt32(pb.Name[0]) - 97;
            int pbRow = Convert.ToInt32(pb.Name[1].ToString()) - 1; // a is column 0, row is 4 in 'a4'
            // this is the row and column of the highlighted tile (picturebox)

            // Board.Tiles[hColumn, hRow].TilePiece = tempPiece;
            // Board.Tiles[tempColumn, tempRow].TilePiece = null;

            //Board.Tiles[pbColumn, pbRow].TilePiece = tempPiece;
            //Board.Tiles[tempPiece.Col, tempPiece.Row].TilePiece = null;

            //tempIndex = (tempPiece.Row * 8) + tempPiece.Col; // the piece is not there, so set the event as blank tile
            //BoardTable.Controls[tempIndex].Click -= PiecePBClicked;
            //BoardTable.Controls[tempIndex].Click += BlankPBClicked;

            int tCol, tRow;

            foreach(Move mv in tempMoves)
            {
                if(mv.Row == pbRow && mv.Column == pbColumn) // if the picturebox corresponds to a move
                {
                    Board.Tiles[mv.Column, mv.Row].TilePiece = mv.movedPiece;
                    tCol = Convert.ToInt32(tempTile.column) - 97;
                    Board.Tiles[tCol, tempTile.row].TilePiece = null;
                }
            }
            MessageBox.Show("Move made");
            DrawTable();
        }
    }
}