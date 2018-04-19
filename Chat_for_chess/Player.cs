using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChessGame
{
    class Player
    {
        public ChessBoard CB=new ChessBoard();
        bool PlayerColor;
        public bool YourTurn;
        public Player(bool color)
        {
            PlayerColor = color;
            YourTurn = color;
           
            if (!color)
            {
                CB.BoardForBlack();
            }
        }

        public bool Move(int x,int y ,int to_x,int to_y)
        {
            if(PlayerColor)
            {
                if(CB.CheckIfWhiteInPosition(x, y))
                {
                    return CB.WhiteMove(x,y,to_x, to_y);
                }
            }
            else
            {
                if (CB.CheckIfBlackInPosition(x, y))
                {
                    return CB.BlackMove(x, y, to_x, to_y);
                }
            }
            return false;
        }

    }
}
