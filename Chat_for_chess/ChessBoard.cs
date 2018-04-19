using System.Collections.Generic;
using System;
using System.Text;
namespace TextChessGame
{
    public class ChessBoard
    {
        private const int length = 8, width = 8;
        public char[,] arr = new char[width, length];
        private List<AFigure> LstWhite=new List<AFigure>();
        private List<AFigure> LstBlack = new List<AFigure>();
        public ChessBoard()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    arr[i, j] = ' ';
                }
            }
            for (int i = 0; i < 8; i++)
            {
                LstWhite.Add(new Pawn(i, 6, true));
                LstBlack.Add(new Pawn(i, 1, false));
            }
            LstWhite.Add(new Bishop(2, 7, true));
            LstWhite.Add(new Bishop(5, 7, true));
            LstBlack.Add(new Bishop(2, 0, false));
            LstBlack.Add(new Bishop(5, 0, false));

            LstWhite.Add(new Rook(0, 7, true));
            LstWhite.Add(new Rook(7, 7, true));
            LstBlack.Add(new Rook(0, 0, false));
            LstBlack.Add(new Rook(7, 0, false));

            LstWhite.Add(new Knight(1, 7, true));
            LstWhite.Add(new Knight(6, 7, true));
            LstBlack.Add(new Knight(1, 0, false));
            LstBlack.Add(new Knight(6, 0, false));

            LstWhite.Add(new King(4, 7, true));
            LstBlack.Add(new King(3, 0, false));

            LstWhite.Add(new Queen(3, 7, true));
            LstBlack.Add(new Queen(4, 0, false));
            foreach (var Figure in LstWhite)
            {
                Figure.SetFigureInPlace(this);
            }
            foreach (var Figure in LstBlack)
            {
                Figure.SetFigureInPlace(this);
            }
        }
        public void Show()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(arr[j, i]);
                }
                Console.WriteLine();
            }
        }
        public bool CheckIfBlackInPosition(int x,int y)
        {
            foreach (var Figure in LstBlack)
            {
                if (Figure.x == x && Figure.y == y)
                    return true;
            }
            return false;
        }
        public bool CheckIfWhiteInPosition(int x, int y)
        {
            foreach (var Figure in LstWhite)
            {
                if (Figure.x == x && Figure.y == y)
                    return true;
            }
            return false;
        }
        public bool WhiteMove(int x,int y,int to_x,int to_y)
        {
            foreach (var Figure in LstWhite)
            {
                if (Figure.x == x && Figure.y == y)
                    return( Figure.Move(this,to_x,to_y));
            }
            return false;
        }
        public bool BlackMove(int x, int y, int to_x, int to_y)
        {
            foreach (var Figure in LstBlack)
            {
                if (Figure.x == x && Figure.y == y)
                    return (Figure.Move(this, to_x, to_y));
            }
            return false;
        }
        public void DeleteFigure(int x,int y,bool Color)
        {
            if(Color)
            {
                foreach (var Figure in LstBlack)
                {
                    if (Figure.x == x && Figure.y == y)
                    {
                        LstBlack.Remove(Figure);
                        return;
                    }
                }
            }
            else
            {
                foreach (var Figure in LstWhite)
                {
                    if (Figure.x == x && Figure.y == y)
                    {
                        LstWhite.Remove(Figure);
                        return;
                    }
                }
            }
        }

        public void BoardForBlack()
        {
            char[,] arr2 = new char[8, 8];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    arr2[i, j] = arr[7 - i, 7 - j];
                    
                }
            }
            foreach (var Figure in LstWhite)
            {
                Figure.x = 7 - Figure.x;
                Figure.y = 7 - Figure.y;
            }
            foreach (var Figure in LstBlack)
            {
                Figure.x = 7 - Figure.x;
                Figure.y = 7 - Figure.y;
            }
            arr = arr2;
        }
        public void FromBytes(byte[] a)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    arr[i, j] = (char)a[i*8+j];
                }
            }
            LstBlack.Clear();
            LstWhite.Clear();
            SetLists();
        }
        public byte[] ToByte()
        {
            byte[] a = new byte[64];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    a[i * 8 + j] = (byte)arr[i, j];
                  
                }
            }
            return a;
        }
        public void SetLists()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    switch (arr[i,j])
                    {
                        case 'p':
                            LstBlack.Add(new Pawn(i, j, false));
                            break;
                        case 'h':
                            LstBlack.Add(new Knight(i, j, false));
                            break;
                        case 'k':
                            LstBlack.Add(new King(i, j, false));
                            break;
                        case 'q':
                            LstBlack.Add(new Queen(i, j, false));
                            break;
                        case 'r':
                            LstBlack.Add(new Rook(i, j, false));
                            break;
                        case 'b':
                            LstBlack.Add(new Bishop(i, j, false));
                            break;
                        case 'P':
                            LstWhite.Add(new Pawn(i, j, true));
                            break;
                        case 'H':
                            LstWhite.Add(new Knight(i, j, true));
                            break;
                        case 'K':
                            LstWhite.Add(new King(i, j, true));
                            break;
                        case 'Q':
                            LstWhite.Add(new Queen(i, j, true));
                            break;
                        case 'R':
                            LstWhite.Add(new Rook(i, j, true));
                            break;
                        case 'B':
                            LstWhite.Add(new Bishop(i, j, true));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        //public override string ToString()
        //{
        //    Show();
        //    return base.ToString();
        //}

    }
}