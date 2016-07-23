using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    internal class Player
    {
        public List<Pawn> Pawns = new List<Pawn>();

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
                    Pawns.Add(new Pawn(0, i, pawnName, teamName));
                    Pawns.Add(new Pawn(1, i + 1, pawnName, teamName));
                    Pawns.Add(new Pawn(2, i, pawnName, teamName));
                    Pawns.Add(new Pawn(3, i + 1, pawnName, teamName));
                }
                else
                {
                    Pawns.Add(new Pawn(6, i, pawnName, teamName));
                    Pawns.Add(new Pawn(7, i + 1, pawnName, teamName));
                    Pawns.Add(new Pawn(8, i, pawnName, teamName));
                    Pawns.Add(new Pawn(9, i + 1, pawnName, teamName));
                }
            }
        }

        public void ChangePawnValue(int currentX, int currentY, int newX, int newY, string intention)
        {
            switch (intention)
            {
                case "MovePawn":
                    {
                        if (!PawnExist(currentX, currentY)) return;
                        if (!NewLocationEmpty(newX, newY)) return;
                        var pawn = Pawns.FirstOrDefault(x => x.XCoordinates == currentX && x.YCoordinates == currentY);
                        ChangePawnLocation(pawn, newX, newY);
                        return;
                    }
            }
            
        }

        public bool PawnExist(int currentX, int currentY)
        {
            var pawn = Pawns.Exists(x => x.XCoordinates == currentX && x.YCoordinates == currentY);
            return pawn;
        }

        public bool NewLocationEmpty(int newX, int newY)
        {
            return !Pawns.Exists(x => x.XCoordinates == newX && x.YCoordinates == newY);
        }

        public void ChangePawnLocation(Pawn selectedPawn, int newX, int newY)
        {
            selectedPawn.XCoordinates = newX;
            selectedPawn.YCoordinates = newY;
        }
    }
}
