using System;
using OpenTK;


namespace Minecraft
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(1280, 720);
            Game gm = new Game(window);
        }
    }
}
