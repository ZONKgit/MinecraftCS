using System;
using OpenTK;


namespace Minecraft
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(720, 720);
            Game gm = new Game(window);
        }
    }
}
