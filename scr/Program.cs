using Game.Dev;
using Game.ScreenUI;

namespace Game
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            OldScreen.SetTextColor();

            var game = new Core.Game();
            game.Run();

            #if DEBUG

            var playground = new Playground();
            playground.Run();

            #endif
            
            Console.ReadLine();
        }
    }
}