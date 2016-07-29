namespace Checkers
{
    internal class Game
    {
        private readonly Player _playerOne = new Player("White");
        private readonly Player _playerTwo = new Player("Black");
        private readonly Board _board = new Board();
        private bool _turn;

        public void PlayerTurn(int currentX, int currentY, int newX, int newY)
        {
            if (_turn)
            {
                StartTurn( currentX,  currentY,  newX,  newY, _playerOne, _playerTwo, "White");
                _turn = false;
            }
            else
            {
                StartTurn(currentX, currentY, newX, newY, _playerTwo, _playerOne, "Black");
                _turn = true;
            }
            
        }

        public void StartTurn(int currentX, int currentY, int newX, int newY, Player currentPlayer, Player enemyPlayer, string teamName)
        {
            _board.CheckJumpPossible(currentX, currentY, currentPlayer, enemyPlayer);
            _board.MovePawn(currentX, currentY, newX, newY, currentPlayer, enemyPlayer, teamName);
        }

    }
}
