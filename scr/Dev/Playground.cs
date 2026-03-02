using Game.ScreenUI;

namespace Game.Dev;

public class Playground
{
    public void Run()
    {
        ScreenUtils.PrintHeader('=', ConsoleColor.Red);
        ScreenUtils.AskOptions([
            new("a", () => Console.WriteLine("a")),
            new("b", () => Console.WriteLine("b"))
        ]);
    }
}