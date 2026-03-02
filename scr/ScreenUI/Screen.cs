namespace Game.ScreenUI;

public static class Screen
{
    public static void Print(
        string text, 
        ConsoleColor color = ConsoleColor.White
    ) =>
        ExecuteWithColor(
            () => Console.Write(text), 
            color
        );

    public static void PrintLine(
        string text, 
        ConsoleColor color = ConsoleColor.White
    ) =>
        ExecuteWithColor(
            () => Console.WriteLine(text), 
            color
        );

    public static string GetInput() =>
        Console.ReadLine() ?? string.Empty;

    public static string GetInputAfterPrint(
        string text,
        ConsoleColor color = ConsoleColor.White
    )
    {
        Print(text, color);
        return GetInput();
    }

    public static string GetInputAfterPrintLine(
        string text,
        ConsoleColor color = ConsoleColor.White
    )
    {
        PrintLine(text, color);
        return GetInput();
    }

    private static void ExecuteWithColor(
        Action action, 
        ConsoleColor color
    )
    {
        var previousColor = Console.ForegroundColor;

        try
        {
            Console.ForegroundColor = color;
            action();
        }
        finally
        {
            Console.ForegroundColor = previousColor;
        }
    }
}