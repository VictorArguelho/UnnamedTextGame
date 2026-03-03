namespace Game.ScreenUI;

public static class Screen
{
    public const ConsoleColor DEFAULT_COLOR = ConsoleColor.White;

    public static void BreakLine() =>
        Console.Write("\n");

    public static void Print(
        string text, 
        ConsoleColor color = DEFAULT_COLOR
    ) =>
        ExecuteWithColor(
            () => Console.Write(text), 
            color
        );

    public static void PrintLine(
        string text, 
        ConsoleColor color = DEFAULT_COLOR
    ) =>
        ExecuteWithColor(
            () => Console.WriteLine(text), 
            color
        );

    public static string GetInput() =>
        Console.ReadLine() ?? string.Empty;

    public static string GetInputAfterPrint(
        string text,
        ConsoleColor color = DEFAULT_COLOR
    )
    {
        Print(text, color);
        return GetInput();
    }

    public static string GetInputAfterPrintLine(
        string text,
        ConsoleColor color = DEFAULT_COLOR
    )
    {
        PrintLine(text, color);
        return GetInput();
    }

    private static void ExecuteWithColor(
        Action action, 
        ConsoleColor color = DEFAULT_COLOR
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