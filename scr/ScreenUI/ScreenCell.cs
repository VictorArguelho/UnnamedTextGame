namespace Game.ScreenUI;

public struct ScreenCell(
    char chr,
    ConsoleColor chrColor,
    ConsoleColor backgroundColor
)
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
}