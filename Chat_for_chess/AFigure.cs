using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChessGame
{
    abstract class AFigure
    {
        public int x;
        public int y;
        public char Marker;
        public bool Color;
        abstract public bool Move(ChessBoard CB, int to_x, int to_y);
        public void SetFigureInPlace(ChessBoard CB)
        {
            CB.arr[x, y] = Marker;
        }
        
    }

    class Pawn : AFigure
    { bool FirstMove = true;
        public Pawn(int x, int y, bool Color)
        {
            this.x = x;
            this.y = y;
            this.Color = Color;
            if (Color)
            {
                this.Marker = 'P';
            }
            else
                this.Marker = 'p';
        }
        public override bool Move(ChessBoard CB, int to_x, int to_y)
        {
            if (x == to_x && to_y == y - 1)
            {
                if (!CB.CheckIfBlackInPosition(to_x,to_y) || !CB.CheckIfWhiteInPosition(to_x, to_y))
                {
                    CB.arr[to_x, to_y] = Marker;
                    CB.arr[x, y] = ' ';
                    x = to_x;
                    y = to_y;
                    FirstMove = false;
                    return true;
                }
            }
            else if((x == to_x-1)|| (x == to_x + 1) && to_y == y - 1)
            {
                if(Color&&CB.CheckIfBlackInPosition(to_x,to_y)||!Color&&CB.CheckIfWhiteInPosition(to_x,to_y))
                {
                    CB.DeleteFigure(to_x, to_y, Color);
                    CB.arr[to_x, to_y] = Marker;
                    CB.arr[x, y] = ' ';
                    x = to_x;
                    y = to_y;
                    return true;
                }
            }
            else if(x == to_x && to_y == y - 2&&FirstMove)
            {
                if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                {
                    CB.arr[to_x, to_y] = Marker;
                    CB.arr[x, y] = ' ';
                    x = to_x;
                    y = to_y;
                    FirstMove = false;
                    return true;
                }
            }
            return false;
        }
    }

    class Rook : AFigure
    {
        public Rook(int x, int y, bool Color)
        {
            this.x = x;
            this.y = y;
            this.Color = Color;
            if (Color)
            {
                this.Marker = 'R';
            }
            else
                this.Marker = 'r';
        }
        public override bool Move(ChessBoard CB, int to_x, int to_y)
        {
            if (x == to_x)
            {
                if (to_y > y)
                {
                    for (int i = y + 1; i < to_y; i++)
                    {
                        if (CB.arr[x, i] != ' ')
                            return false;
                    }
                    
                }
                else
                {
                    for (int i = y - 1; i > to_y; i--)
                    {
                        if (CB.arr[x, i] != ' ')
                            return false;
                    }
                }
            }
            if (y == to_y)
            {
                if (to_x > x)
                {
                    for (int i = x + 1; i < to_x; i++)
                    {
                        if (CB.arr[i, y] != ' ')
                            return false;
                    }
                }
                else
                {
                    for (int i = x - 1; i > to_x; i--)
                    {
                        if (CB.arr[i, y] != ' ')
                            return false;
                    }
                }
            }
            if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
            {
                CB.arr[to_x, to_y] = Marker;
                CB.arr[x, y] = ' ';
                x = to_x;
                y = to_y;
                return true;
            }
            else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
            {
                CB.DeleteFigure(to_x, to_y, Color);
                CB.arr[to_x, to_y] = Marker;
                CB.arr[x, y] = ' ';
                x = to_x;
                y = to_y;
                return true;
            }
            return false;
        }
    }

    class Bishop : AFigure
    {
        public Bishop(int x, int y, bool Color)
        {
            this.x = x;
            this.y = y;
            this.Color = Color;
            if (Color)
            {
                this.Marker = 'B';
            }
            else
                this.Marker = 'b';
        }
        public override bool Move(ChessBoard CB, int to_x, int to_y)
        {
            bool tmp = false;
            if (to_x > x)
            {
                if (to_y > y)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        if (x + i == to_x-1 && y + i == to_y -1&& !CB.CheckIfBlackInPosition(x+i, y+i) || !CB.CheckIfWhiteInPosition(x+i, y+i))
                        {
                            tmp = true;
                        }
                    }
                    if (tmp)
                    {
                        if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                        else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.DeleteFigure(to_x, to_y, Color);
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                    }
                    return tmp;
                }
                if (to_y < y)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        if (x + i == to_x-1 && y - i == to_y+1 && !CB.CheckIfBlackInPosition(x+i, y-i) || !CB.CheckIfWhiteInPosition(x+i, y-i))
                        {
                            tmp = true;
                        }
                    }
                    if (tmp)
                    {
                        if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                        else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.DeleteFigure(to_x, to_y, Color);
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                    }
                    return tmp;
                }
            }
            if (to_x < x)
            {
                if (to_y > y)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        if (x - i == to_x+1 && y + i == to_y-1 && !CB.CheckIfBlackInPosition(x-i, y+i) || !CB.CheckIfWhiteInPosition(x-i, y+i))
                        {
                            tmp = true;
                        }
                    }
                    if (tmp)
                    {
                        if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' '; 
                            x = to_x;
                            y = to_y;return true;
                        }
                        else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.DeleteFigure(to_x, to_y, Color);
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                    }
                    return tmp;
                }
                if (to_y < y)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        if (x - i == to_x+1 && y - i == to_y+1 && !CB.CheckIfBlackInPosition(x-i, y-i) || !CB.CheckIfWhiteInPosition(x-i, y-i))
                        {
                            tmp = true;
                        }
                    }
                    if (tmp)
                    {
                        if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                        else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.DeleteFigure(to_x, to_y, Color);
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                    }
                    return tmp;
                }
            }
            return false;
        }
    }

    class Knight : AFigure
    {
        public Knight(int x, int y, bool Color)
        {
            this.x = x;
            this.y = y;
            this.Color = Color;
            if (Color)
            {
                this.Marker = 'H';
            }
            else
                this.Marker = 'h';
        }
        public override bool Move(ChessBoard CB, int to_x, int to_y)
        {
           
              
            if (((to_x == x + 1 || to_x == x - 1) && (to_y == y + 2 || to_y == y - 2)) || ((to_x == x + 2 || to_x == x - 2) && (to_y == y + 1 || to_y == y - 1)))
            { if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                {
                    CB.arr[to_x, to_y] = Marker;
                    CB.arr[x, y] = ' ';
                    x = to_x;
                    y = to_y;
                    return true;
                }
                else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
                {
                    CB.DeleteFigure(to_x, to_y, Color);
                    CB.arr[to_x, to_y] = Marker;
                    CB.arr[x, y] = ' ';
                    x = to_x;
                    y = to_y;
                    return true;
                }
            }
            return false;
        }
    }

    class King : AFigure
    {
        public King(int x, int y, bool Color)
        {
            this.x = x;
            this.y = y;
            this.Color = Color;
            if (Color)
            {
                this.Marker = 'K';
            }
            else
                this.Marker = 'k';
        }
        public override bool Move(ChessBoard CB, int to_x, int to_y)
        {
            if ((x == to_x + 1 || x == to_x - 1 || x == to_x) && (y == to_y + 1 || y == to_y - 1 || y == to_y))
            { if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                {
                    CB.arr[to_x, to_y] = Marker;
                    CB.arr[x, y] = ' ';
                    x = to_x;
                    y = to_y;
                    return true;
                }
                else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
                {
                    CB.DeleteFigure(to_x, to_y, Color);
                    CB.arr[to_x, to_y] = Marker;
                    CB.arr[x, y] = ' ';
                    x = to_x;
                    y = to_y;
                    return true;
                }
            }
            return false;
        }
    }


    class Queen : AFigure
    {
        public Queen(int x, int y, bool Color)
        {
            this.x = x;
            this.y = y;
            this.Color = Color;
            if (Color)
            {
                this.Marker = 'Q';
            }
            else
                this.Marker = 'q';
        }
        public override bool Move(ChessBoard CB, int to_x, int to_y)
        {
            if (x == to_x)
            {
                if (to_y > y)
                {
                    for (int i = y + 1; i < to_y; i++)
                    {
                        if (CB.arr[x, i] != ' ')
                            return false;
                    }
                }
                else
                {
                    for (int i = y - 1; i > to_y; i--)
                    {
                        if (CB.arr[x, i] != ' ')
                            return false;
                    }
                }
            }
            if (y == to_y)
            {
                if (to_x > x)
                {
                    for (int i = x + 1; i < to_x; i++)
                    {
                        if (CB.arr[i, y] != ' ')
                            return false;
                    }
                }
                else
                {
                    for (int i = x - 1; i > to_x; i--)
                    {
                        if (CB.arr[i, y] != ' ')
                            return false;
                    }
                }
            }
            if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
            {
                CB.arr[to_x, to_y] = Marker;
                CB.arr[x, y] = ' ';
                x = to_x;
                y = to_y;
                return true;
            }
            else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
            {
                CB.DeleteFigure(to_x, to_y, Color);
                CB.arr[to_x, to_y] = Marker;
                CB.arr[x, y] = ' ';
                x = to_x;
                y = to_y;
                return true;
            }

            bool tmp = false;
            if (to_x > x)
            {
                if (to_y > y)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        if (x + i == to_x - 1 && y + i == to_y - 1 && !CB.CheckIfBlackInPosition(x+i, y+i) || !CB.CheckIfWhiteInPosition(x+i, y+i))
                        {
                            tmp = true;
                        }
                    }
                    if (tmp)
                    {
                        if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                        else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.DeleteFigure(to_x, to_y, Color);
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                    }
                    return tmp;
                }
                if (to_y < y)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        if (x + i == to_x - 1 && y - i == to_y + 1 && !CB.CheckIfBlackInPosition(x+i, y-i) || !CB.CheckIfWhiteInPosition(x+i, y-i))
                        {
                            tmp = true;
                        }
                    }
                    if (tmp)
                    {
                        if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                        else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.DeleteFigure(to_x, to_y, Color);
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                    }
                    return tmp;
                }
            }
            if (to_x < x)
            {
                if (to_y > y)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        if (x - i == to_x + 1 && y + i == to_y - 1 && !CB.CheckIfBlackInPosition(x-i, y+i) || !CB.CheckIfWhiteInPosition(x-i, y+i))
                        {
                            tmp = true;
                        }
                    }
                    if (tmp)
                    {
                        if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                            return true;
                        }
                        else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.DeleteFigure(to_x, to_y, Color);
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                    }
                    return tmp;
                }
                if (to_y < y)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        if (x - i == to_x + 1 && y - i == to_y + 1 && !CB.CheckIfBlackInPosition(x-i, y-i) || !CB.CheckIfWhiteInPosition(x-i, y-i))
                        {
                            tmp = true;
                        }
                    }
                    if (tmp)
                    {
                        if (!CB.CheckIfBlackInPosition(to_x, to_y) && !CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                        else if (Color && CB.CheckIfBlackInPosition(to_x, to_y) || !Color && CB.CheckIfWhiteInPosition(to_x, to_y))
                        {
                            CB.DeleteFigure(to_x, to_y, Color);
                            CB.arr[to_x, to_y] = Marker;
                            CB.arr[x, y] = ' ';
                            x = to_x;
                            y = to_y;
                        }
                    }
                    return tmp;
                }
            }
            return false;
        }
    }
}
