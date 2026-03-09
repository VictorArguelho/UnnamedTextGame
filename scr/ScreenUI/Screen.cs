using Game.Mathematics;

namespace Game.ScreenUI;

public static class Screen
{
    public static int WindowWidth => ScreenBuffer.Width;
    public static int WindowHeight { get; private set; }
    public static int BufferHeight => ScreenBuffer.Height;

    public static void Resize(
        int windowWidth, 
        int windowHeight, 
        int BufferHeight
    )
    {
        WindowHeight = windowHeight;
#pragma warning disable CA1416 // Validar a compatibilidade da plataforma
        Console.WindowWidth = windowWidth;
        Console.WindowHeight = windowHeight;
        Console.BufferHeight = BufferHeight;
#pragma warning restore CA1416 // Validar a compatibilidade da plataforma
        ScreenBuffer.ResizeBuffer(windowWidth, BufferHeight);
    }

    public static void Clear() =>
        ScreenBuffer.ClearBuffer();

    public static void SetCellChr(
        Vector2Int position, 
        char chr) =>
        ScreenBuffer.SetCellChr(
            position, 
            chr
        );

    public static void SetCellChrColor(
    Vector2Int position, 
    ConsoleColor chrColor) =>
    ScreenBuffer.SetCellChrColor(
        position, 
        chrColor
    );

    public static void SetCellBackgroundColor(
    Vector2Int position, 
    ConsoleColor backgroundColor) =>
    ScreenBuffer.SetCellBackgroundColor(
        position, 
        backgroundColor
    );
    
    public static void Render() =>
        ScreenRenderer.RenderScreen(
            ScreenBuffer.GetDirtyCells());
}