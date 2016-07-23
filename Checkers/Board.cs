using System;

namespace Checkers
{
    internal class Board
    {
        private Player _playerOne = new Player("White");
        private Player _playerTwo = new Player("Black");

        public void MovePawn(int currentX, int currentY, int newX, int newY, Player selectedPlayer)
        {
            selectedPlayer.ChangePawnValue(currentX, currentY, newX, newY, "MovePawn");
        }
    }
}
