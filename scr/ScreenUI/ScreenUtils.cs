namespace Game.ScreenUI;

public static class ScreenUtils
{
    public static void PrintHeader(
        char chr, 
        ConsoleColor color = ConsoleColor.Gray
    )
    {
        OldScreen.Print(
            new(
                chr, 
                Console.WindowWidth
            ), 
            color
        );
    }

    public static void AskOptions(
        IReadOnlyList<Option> options,
        ConsoleColor color = OldScreen.DEFAULT_COLOR,
        ConsoleColor reAskColor = ConsoleColor.DarkRed
    )
    {
        OldScreen.PrintLine("Escolha uma das opções (digite o número dela): ", color);
        OldScreen.BreakLine();
        PrintOptions(options);
        OldScreen.BreakLine();
        var op = GetOption(options, reAskColor);
        options[op].Action();
    }

    private static void PrintOptions(IReadOnlyList<Option> options)
    {
        for(int i = 0; i < options.Count; i++)
        {
            var op = options[i];
            OldScreen.PrintLine(
                $"{i + 1}.{op.Text}", 
                op.Color
            );
        }
    }

    private static int GetOption(
        IReadOnlyList<Option> options,
        ConsoleColor reAskColor
    )
    {
        int opNum = -1;
        string opText = string.Empty;
        opText = OldScreen.GetInputAfterPrint("Opção escolhida: ");

        while (
            !int.TryParse(opText, out opNum) ||
            opNum < 1 ||
            opNum > options.Count
        )
            opText = OldScreen.GetInputAfterPrint("Opção inválida, escolha novamente: ", reAskColor);
            
        return opNum - 1;
    }
}