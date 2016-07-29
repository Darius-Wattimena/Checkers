using System.Security.Authentication.ExtendedProtection.Configuration;

namespace Checkers
{
    internal class Piece : IPiece
    {
        public Piece(int x , int y, string name, string team)
        {
            XCoordinates = x;
            YCoordinates = y;
            Name = name;
            Team = team;
        }

        public int XCoordinates { get; set; }
        public int YCoordinates { get; set; }
        public string Name { get; set; }
        public string Team { get; }
    }
}
