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

        BlockRenderer block1 = new BlockRenderer();
        BlockRenderer block2 = new BlockRenderer();

        public Game(GameWindow window)
        {
            this.window = window;
            Start();
        }
        void Start()
        {
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
            Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI * (45 / 180f), window.Width / window.Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        void renderF(object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      
            camera.Update();

            block1.PosX = -10.0f;
            block1.PosY = -20.0f;
            block1.PosZ = 0.0f;

            block2.PosX = 10.0f;
            block2.PosY = 20.0f;
            block2.PosZ = 10.0f;

            block1.Update();
            block2.Update();

            window.SwapBuffers();

        }

        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.3f, 0.3f, 0.3f, 0);
            GL.Enable(EnableCap.DepthTest);
        }
    }
}
