using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Minecraft.Classes
{
    class BlockRenderer
    {
        public Vector3 position;
        public Vector3 scale;

        public BlockRenderer(float posX = 0, float posY = 0, float posZ = 0, float scaleX = 1, float scaleY = 1, float scaleZ = 1)
        {
            position.X = posX;
            position.Y = posY;
            position.Z = posZ;

            scale.X = scaleX;
            scale.Y = scaleY;
            scale.Z = scaleZ;
        }

        public void Update()
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(-1 * scale.X + position.X, 1 * scale.Y + position.Y, 1 * scale.Z + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, 1 * scale.Y + position.Y, -1 * scale.Z + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, -1 * scale.Y + position.Y, -1 * scale.Z + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, -1 * scale.Y + position.Y, 1 * scale.Z + position.Z);

            GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(1 * scale.X + position.X, 1 * scale.Y + position.Y, 1 * scale.Z + position.Z);
            GL.Vertex3(1 * scale.X + position.X, 1 * scale.Y + position.Y, -1 * scale.Z + position.Z);
            GL.Vertex3(1 * scale.X + position.X, -1 * scale.Y + position.Y, -1 * scale.Z + position.Z);
            GL.Vertex3(1 * scale.X + position.X, -1 * scale.Y + position.Y, 1 * scale.Z + position.Z);

            GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(1 * scale.X + position.X, -1 * scale.Y + position.Y, 1 * scale.Z + position.Z);
            GL.Vertex3(1 * scale.X + position.X, -1 * scale.Y + position.Y, -1 * scale.Z + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, -1 * scale.Y + position.Y, -1 * scale.Z + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, -1 * scale.Y + position.Y, 1.0 + position.Z);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(1 * scale.X + position.X, 1 * scale.Y + position.Y, 1.0 + position.Z);
            GL.Vertex3(1 * scale.X + position.X, 1 * scale.Y + position.Y, -1.0 + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, 1 * scale.Y + position.Y, -1 * scale.Z + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, 1 * scale.Y + position.Y, 1 * scale.Z + position.Z);

            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(1 * scale.X + position.X, 1 * scale.Y + position.Y, -1 * scale.Z + position.Z);
            GL.Vertex3(1 * scale.X + position.X, -1 * scale.Y + position.Y, -1 * scale.Z + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, -1 * scale.Y + position.Y, -1 * scale.Z + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, 1 * scale.Y + position.Y, -1 * scale.Z + position.Z);

            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(1 * scale.X + position.X, 1 * scale.Y + position.Y, 1 * scale.Z + position.Z);
            GL.Vertex3(1 * scale.X + position.X, -1 * scale.Y + position.Y, 1 * scale.Z + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, -1 * scale.Y + position.Y, 1 * scale.Z + position.Z);
            GL.Vertex3(-1 * scale.X + position.X, 1 * scale.Y + position.Y, 1 * scale.Z + position.Z);

            GL.End();
        }
    }
}
