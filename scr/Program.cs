using Game.Dev;

namespace Game
{
    public static class Program
    {
        public static void Main(string[] args)
        {
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