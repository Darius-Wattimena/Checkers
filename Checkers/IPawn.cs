namespace Checkers
{
    internal interface IPawn
    {
        int XCoordinates { get; set; }
        int YCoordinates { get; set; }
        string Name { get; set; }
        string Team { get; }
        bool Alive { get; set; }
    }
}
