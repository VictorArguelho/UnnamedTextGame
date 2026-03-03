namespace Game.ScreenUI;

public readonly struct Option(
    string text,
    Action action,
    ConsoleColor color = Screen.DEFAULT_COLOR
)
{
    public readonly string Text { get; } = text;
    public readonly Action Action { get; } = action;
    public readonly ConsoleColor Color { get; } = color;
}