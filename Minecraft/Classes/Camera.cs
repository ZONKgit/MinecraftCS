using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Mathematics;
using MathematicsMatrix4 = OpenTK.Mathematics.Matrix4; // Псевдоним для OpenTK.Mathematics.Matrix4


namespace Minecraft.Classes
{
    class Camera
    {
        double PosX = 0;
        double PosY = 0;
        double PosZ = -45;

        public void Update()
        {
            GL.Translate(PosX, PosY, PosZ);

            KeyboardState keyboardState = Keyboard.GetState();

            MathematicsMatrix4 mat = new MathematicsMatrix4();
           


            if (keyboardState.IsKeyDown(Key.W))
            {
                PosZ += 1;
            }
            if (keyboardState.IsKeyDown(Key.S))
            {
                PosZ -= 1;
            }
            if (keyboardState.IsKeyDown(Key.A))
            {
                PosX += 1;
            }
            if (keyboardState.IsKeyDown(Key.D))
            {
                PosX -= 1;
            }
            if (keyboardState.IsKeyDown(Key.LShift))
            {
                PosY += 1;
            }
            if (keyboardState.IsKeyDown(Key.Space))
            {
                PosY -= 1;
            }
        }
    }
}
