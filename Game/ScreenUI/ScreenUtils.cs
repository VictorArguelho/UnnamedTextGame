namespace Game.ScreenUI;

public static class ScreenUtils
{
    public static void PrintHeader(
        char chr, 
        ConsoleColor color = ConsoleColor.White
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

    public static void AskOptions(IReadOnlyList<Option> options)
    {
        PrintOptions(options);
        var op = GetOption(options);
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

    private static int GetOption(IReadOnlyList<Option> options)
    {
        int opNum = -1;
        string opText = string.Empty;
        opText = Screen.GetInputAfterPrint("Escolha uma opcao: ");

        while (
            !int.TryParse(opText, out opNum) ||
            opNum < 1 ||
            opNum > options.Count
        )
            opText = Screen.GetInputAfterPrint("Escolha uma opcao valida: ");
            
        return opNum - 1;
    }
}