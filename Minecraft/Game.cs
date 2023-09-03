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
        World world;

        public Game(GameWindow window)
        {
            camera.Aspect = window.Width / window.Height;
            camera.window = window;
            this.window = window;
            
            world = new World();
            world.GenerateWorld();


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
            Matrix4 matrix = camera.GetProjectionMatrix();
            GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        void renderF(object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      
            camera.Update();

            world.Update();

            window.SwapBuffers();

        }

        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.3f, 0.3f, 0.3f, 0);
            GL.Enable(EnableCap.DepthTest);
        }
    }
}
