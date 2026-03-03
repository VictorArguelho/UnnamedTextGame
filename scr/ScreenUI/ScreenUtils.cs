namespace Game.ScreenUI;

public static class ScreenUtils
{
    public static void PrintHeader(
        char chr, 
        ConsoleColor color = ConsoleColor.Gray
    )
    {
        Screen.Print(
            new(
                chr, 
                Console.WindowWidth
            ), 
            color
        );
    }

    public static void AskOptions(
        IReadOnlyList<Option> options,
        ConsoleColor color = Screen.DEFAULT_COLOR,
        ConsoleColor reAskColor = ConsoleColor.DarkRed
    )
    {
        Screen.PrintLine("Escolha uma das opções (digite o número dela): ", color);
        Screen.BreakLine();
        PrintOptions(options);
        Screen.BreakLine();
        var op = GetOption(options, reAskColor);
        options[op].Action();
    }

    private static void PrintOptions(IReadOnlyList<Option> options)
    {
        for(int i = 0; i < options.Count; i++)
        {
            var op = options[i];
            Screen.PrintLine(
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
        opText = Screen.GetInputAfterPrint("Opção escolhida: ");

        while (
            !int.TryParse(opText, out opNum) ||
            opNum < 1 ||
            opNum > options.Count
        )
            opText = Screen.GetInputAfterPrint("Opção inválida, escolha novamente: ", reAskColor);
            
        return opNum - 1;
    }
}