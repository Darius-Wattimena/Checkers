using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    internal class Player
    {
        public List<Piece> WhitePieces = new List<Piece>();
        public List<Piece> BlackPieces = new List<Piece>();

        public Player(string team)
        {
            CreatePawns("Men", team);
        }

        public void CreatePawns(string pawnName, string teamName)
        {
            for (var i = 0; i < 10; i = i + 2)
            {
                if (teamName == "White")
                {
                    WhitePieces.Add(new Piece(0, i, pawnName, teamName));
                    WhitePieces.Add(new Piece(1, i + 1, pawnName, teamName));
                    WhitePieces.Add(new Piece(2, i, pawnName, teamName));
                    WhitePieces.Add(new Piece(3, i + 1, pawnName, teamName));
                }
                else
                {
                    BlackPieces.Add(new Piece(6, i, pawnName, teamName));
                    BlackPieces.Add(new Piece(7, i + 1, pawnName, teamName));
                    BlackPieces.Add(new Piece(8, i, pawnName, teamName));
                    BlackPieces.Add(new Piece(9, i + 1, pawnName, teamName));
                }
            }
        }

        public void ChangePieceValue(int currentX, int currentY, int newX, int newY, string intention, List<Piece> playerList, List<Piece> enemyList)
        {
            switch (intention)
            {
                case "MovePiece":
                    {
                        if (!PieceExist(currentX, currentY, playerList)) return;
                        if (!NewLocationEmpty(newX, newY)) return;
                        var piece = playerList.FirstOrDefault(x => x.XCoordinates == currentX && x.YCoordinates == currentY);
                        ChangePieceLocation(piece, false, GetDirection(currentX, currentY, newX, newY, false));
                        return;
                    }
                case "JumpPiece":
                    {
                        if (!PieceExist(currentX, currentY, playerList)) return;
                        if (!NewLocationEmpty(newX, newY)) return;
                        var piece = playerList.FirstOrDefault(x => x.XCoordinates == currentX && x.YCoordinates == currentY);
                        var direction = GetDirection(currentX, currentY, newX, newY, true);
                        RemovePiece(currentX, currentY, direction, enemyList);
                        ChangePieceLocation(piece, true, direction);
                        return;
                    }
            }
        }

        public bool PieceExist(int selectedX, int selectedY, List<Piece> selectedList)
        {
            return selectedList.Exists(x => x.XCoordinates == selectedX && x.YCoordinates == selectedY);
        }

        public bool NewLocationEmpty(int newX, int newY)
        {
            if (WhitePieces.Exists(x => x.XCoordinates == newX && x.YCoordinates == newY))
            {
                return false;
            }
            return !BlackPieces.Exists(x => x.XCoordinates == newX && x.YCoordinates == newY);
        }

        public void RemovePiece(int selectedX, int selectedY, string direction, List<Piece> selectedList)
        {
            switch (direction)
            {
                case "NE":
                {
                    var selectedPiece = selectedList.Where(x => x.XCoordinates == selectedX - 1 && x.YCoordinates == selectedY + 1);
                    selectedList.Remove(selectedPiece.GetEnumerator().Current);
                    return;
                }
                case "NW":
                {
                    var selectedPiece = selectedList.Where(x => x.XCoordinates == selectedX - 1 && x.YCoordinates == selectedY - 1);
                    selectedList.Remove(selectedPiece.GetEnumerator().Current);
                    return;
                }
                case "SE":
                {
                    var selectedPiece = selectedList.Where(x => x.XCoordinates == selectedX + 1 && x.YCoordinates == selectedY + 1);
                    selectedList.Remove(selectedPiece.GetEnumerator().Current);
                    return;
                }
                case "SW":
                {
                    var selectedPiece = selectedList.Where(x => x.XCoordinates == selectedX + 1 && x.YCoordinates == selectedY - 1);
                    selectedList.Remove(selectedPiece.GetEnumerator().Current);
                    return;
                }
            }
        }

        public string GetDirection(int currentX, int currentY, int newX, int newY, bool jump)
        {
            var changeValue = jump ? 2 : 1;
            if (currentX - changeValue == newX && currentY + changeValue == newY) return "NE";
            if (currentX - changeValue == newX && currentY - changeValue == newY) return "NW";
            if (currentX + changeValue == newX && currentY + changeValue == newY) return "SE";
            if (currentX + changeValue == newX && currentY - changeValue == newY) return "SW";
            return "";
        }

        public void ChangePieceLocation(Piece selectedPiece, bool jump, string direction)
        {
            var changeValue = jump ? 2 : 1;
            switch (direction)
            {
                case "NE":
                    {
                        selectedPiece.XCoordinates = selectedPiece.XCoordinates - changeValue;
                        selectedPiece.YCoordinates = selectedPiece.YCoordinates + changeValue;
                        return;
                    }
                case "NW":
                    {
                        selectedPiece.XCoordinates = selectedPiece.XCoordinates - changeValue;
                        selectedPiece.YCoordinates = selectedPiece.YCoordinates - changeValue;
                        return;
                    }
                case "SE":
                    {
                        selectedPiece.XCoordinates = selectedPiece.XCoordinates + changeValue;
                        selectedPiece.YCoordinates = selectedPiece.YCoordinates + changeValue;
                        return;
                    }
                case "SW":
                    {
                        selectedPiece.XCoordinates = selectedPiece.XCoordinates + changeValue;
                        selectedPiece.YCoordinates = selectedPiece.YCoordinates - changeValue;
                        return;
                    }
            }
        }
    }
}
