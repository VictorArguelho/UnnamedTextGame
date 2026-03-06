namespace Game.ScreenUI;

public struct ScreenCell(
    char chr = ' ',
    ConsoleColor chrColor = ConsoleColor.White,
    ConsoleColor backgroundColor = ConsoleColor.Black
) : IEquatable<ScreenCell>
{
    private char _chr = chr;
    private ConsoleColor _chrColor = chrColor;
    private ConsoleColor _backgroundColor = backgroundColor;

    public bool Dirty { get; internal set; } = false;
    
    public char Chr
    {
        readonly get => _chr;

        set
        {
            if (value == _chr)
                return;
            _chr = value;
            Dirty = true;
        }
    }

    public ConsoleColor ChrColor
    {
        readonly get => _chrColor;

        set
        {
            if (value == _chrColor)
                return;
            _chrColor = value;
            Dirty = true;
        }
    }

    public ConsoleColor BackgroundColor
    {
        readonly get => _backgroundColor;

        set
        {
            if (value == _backgroundColor)
                return;
            _backgroundColor = value;
            Dirty = true;
        }
    }

        public readonly bool Equals(ScreenCell other) =>
            Chr.Equals(other.Chr) &&
            ChrColor.Equals(other.ChrColor) &&
            BackgroundColor.Equals(other.BackgroundColor);

        public override bool Equals(object? obj) =>
            obj is ScreenCell other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(Chr, ChrColor, BackgroundColor);
}