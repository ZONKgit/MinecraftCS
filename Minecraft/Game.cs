using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Minecraft.Classes;


namespace Minecraft
{
    class Game
    {


        GameWindow window;
        Camera camera = new Camera();

        Block[] chunk;
        
        public Game(GameWindow window)
        {
            camera.Aspect = window.Width / window.Height;
            camera.window = window;
            this.window = window;
            Start();
        }

        void GenerateChunk()
        {
            chunk = new Block[16 * 16 * 16]; // Изменим размер массива для хранения большего числа блоков
            int blockNum = 0;

            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        chunk[blockNum] = new Block(x * 10, y * 10, z * 10);
                        blockNum++;
                    }
                }
            }
        }

        void Start()
        {

            GenerateChunk();


            window.Load += loaded;
            window.Resize += resize;
            window.RenderFrame += renderF;
            window.Run(1.0 / 60);
        }

        void resize(object ob, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 matrix = camera.GetProjectionMatrix();
            GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        void renderF(object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      
            camera.Update();

            // World render
            for (int i = 1; i < chunk.Length; i++)
            {
                chunk[i].Update();
            }

            window.SwapBuffers();

        }

        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.3f, 0.3f, 0.3f, 0);
            GL.Enable(EnableCap.DepthTest);
        }
    }
}
