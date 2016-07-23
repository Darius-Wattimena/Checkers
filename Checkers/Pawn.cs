using System.Security.Authentication.ExtendedProtection.Configuration;

namespace Checkers
{
    internal class Pawn : IPawn
    {
        public Pawn(int x , int y, string name, string team)
        {
            XCoordinates = x;
            YCoordinates = y;
            Name = name;
            Team = team;
            Alive = true;
        }

        public void ChangeCoordinates(int x, int y)
        {
            XCoordinates = x;
            YCoordinates = y;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public int XCoordinates { get; set; }
        public int YCoordinates { get; set; }
        public string Name { get; set; }
        public string Team { get; }
        public bool Alive { get; set; }
    }
}
