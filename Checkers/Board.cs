using System;
using System.Collections.Generic;

namespace Checkers
{
    internal class Board
    {
        public bool CheckJumpPossible(int currentX, int currentY, Player currentPlayer, Player enemyPlayer)
        {
            

            return true;
        }

        public void MovePawn(int currentX, int currentY, int newX, int newY, Player currentPlayer, Player enemyPlayer, string team)
        {
            List<Piece> list;
            List<Piece> enemyList;
            if (team == "White")
            {
                list = currentPlayer.WhitePieces;
                enemyList = enemyPlayer.BlackPieces;
            }
            else
            {
                list = currentPlayer.BlackPieces;
                enemyList = enemyPlayer.WhitePieces;
            }
            currentPlayer.ChangePieceValue(currentX, currentY, newX, newY, "MovePawn", list, enemyList);
        }
    }
}
