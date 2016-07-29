namespace Checkers
{
    internal interface IPiece
    {
        int XCoordinates { get; set; }
        int YCoordinates { get; set; }
        string Name { get; set; }
        string Team { get; }
    }
}
