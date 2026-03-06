namespace Game.ScreenUI;

public static class ScreenRenderer
{
    private static ConsoleColor _currentFg;
    private static ConsoleColor _currentBg;

    public static void RenderScreen(ReadOnlySpan<DirtyScreenCell> cells)
    {
        foreach(var cell in cells)
            RenderCell(cell);
    }
    
    private static void RenderCell(DirtyScreenCell cell)
    {
        var chColor = cell.Cell.ChrColor;
        var bgColor = cell.Cell.BackgroundColor;
        
        Console.SetCursorPosition(
            cell.Position.X, 
            cell.Position.Y);

        if (_currentFg != chColor)
        {
            Console.ForegroundColor = chColor;
            _currentFg = chColor;
        }

        if (_currentBg != bgColor)
        {
            Console.BackgroundColor = bgColor;
            _currentBg = bgColor;
        }

        Console.Write(cell.Cell.Chr);
    }
}