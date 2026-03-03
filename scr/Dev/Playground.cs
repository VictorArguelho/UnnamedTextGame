using Game.ScreenUI;

namespace Game.Dev;

public class Playground
{
    public void Run()
    {
        ScreenUtils.PrintHeader('=', ConsoleColor.Red);
        ScreenUtils.AskOptions([
            new("Opcao A", () => Console.WriteLine("Voce escolheu a opcao A")),
            new("Opcao B", () => Console.WriteLine("Voce escolheu a opcao B"))
        ]);
    }
}