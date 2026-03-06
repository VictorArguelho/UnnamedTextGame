namespace Game.ScreenUI;

public struct ScreenCell(
    char chr = ' ',
    ConsoleColor chrColor = ConsoleColor.White,
    ConsoleColor backgroundColor = ConsoleColor.Black
) : IEquatable<ScreenCell>
{
    public char Chr { get; private set; } = chr;
    public ConsoleColor ChrColor { get; private set; } = chrColor;
    public ConsoleColor BackgroundColor { get; private set; } = backgroundColor;

    public bool SetCell(    
        char chr = ' ',
        ConsoleColor chrColor = ConsoleColor.White,
        ConsoleColor backgroundColor = ConsoleColor.Black
    )
    {
        var isChanged = 
            Chr != chr || 
            ChrColor != chrColor || 
            BackgroundColor != backgroundColor;

        Chr = chr;
        ChrColor = chrColor;
        BackgroundColor = backgroundColor;

        return isChanged; 
    }

    public static bool operator ==(ScreenCell left, ScreenCell right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ScreenCell left, ScreenCell right)
    {
        return !(left == right);
    }

    public readonly bool Equals(ScreenCell other) =>
        Chr.Equals(other.Chr) &&
        ChrColor.Equals(other.ChrColor) &&
        BackgroundColor.Equals(other.BackgroundColor);

    public override readonly bool Equals(object? obj) =>
        obj is ScreenCell other && Equals(other);

    public override readonly int GetHashCode() =>
        HashCode.Combine(Chr, ChrColor, BackgroundColor);
}