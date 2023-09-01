using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Minecraft.Classes
{
    class BlockRenderer
    {
        public double PosX = 0;
        public double PosY = 0;
        public double PosZ = 0;

        public void Update()
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(-10.0 + PosX, 10.0 + PosY, 10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, 10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, -10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, -10.0 + PosY, 10.0 + PosZ);

            GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(10.0 + PosX, 10.0 + PosY, 10.0 + PosZ);
            GL.Vertex3(10.0 + PosX, 10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(10.0 + PosX, -10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(10.0 + PosX, -10.0 + PosY, 10.0 + PosZ);

            GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(10.0 + PosX, -10.0 + PosY, 10.0 + PosZ);
            GL.Vertex3(10.0 + PosX, -10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, -10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, -10.0 + PosY, 10.0 + PosZ);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(10.0 + PosX, 10.0 + PosY, 10.0 + PosZ);
            GL.Vertex3(10.0 + PosX, 10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, 10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, 10.0 + PosY, 10.0 + PosZ);

            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(10.0 + PosX, 10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(10.0 + PosX, -10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, -10.0 + PosY, -10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, 10.0 + PosY, -10.0 + PosZ);

            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(10.0 + PosX, 10.0 + PosY, 10.0 + PosZ);
            GL.Vertex3(10.0 + PosX, -10.0 + PosY, 10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, -10.0 + PosY, 10.0 + PosZ);
            GL.Vertex3(-10.0 + PosX, 10.0 + PosY, 10.0 + PosZ);

            GL.End();
        }
    }
}
