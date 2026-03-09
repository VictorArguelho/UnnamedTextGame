using Game.Mathematics;

namespace Game.ScreenUI;

public static class Terminal
{
    private static Vector2Int _cursorPosition = Vector2Int.Zero;

    public static int WindowWidth => Screen.WindowWidth;
    public static int WindowHeight => Screen.WindowHeight;
    public static int BufferHeight => Screen.BufferHeight;

    public static ConsoleColor TextColor { get; set; } = ConsoleColor.White;
    public static ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;

    public static Vector2Int CursorPosition
    {
        get => _cursorPosition;

        set
        {
            _cursorPosition = new(
                Math.Clamp(value.X, 0, WindowWidth - 1),
                Math.Clamp(value.Y, 0, BufferHeight - 1)
            );
        }
    }

    private static void MoveCursor()
    {
        if(CursorPosition.X + 1 >= WindowWidth)
        {
            if(CursorPosition.Y + 1 >= WindowHeight)
                throw new InvalidOperationException("Ta tentando mover pra fora do limite nessa coisa"); //debug temporario
            CursorPosition = new(
                0,
                CursorPosition.Y + 1
            );
            return;
        }
        CursorPosition += Vector2Int.Right;
    }
}