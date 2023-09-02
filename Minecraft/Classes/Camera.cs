using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using TKMatrix4 = OpenTK.Matrix4; // Псевдоним для OpenTK.Matrix4
using TKMathMatrix4 = OpenTK.Mathematics.Matrix4; // Псевдоним для OpenTK.Mathematics.Matrix4
using TKMathVector3 = OpenTK.Mathematics.Vector3; // Псевдоним для OpenTK.Mathematics.Vector3


namespace Minecraft.Classes
{
    class Camera
    {
        //Constants
        private float SPEED = 2f;
        private float SENSITIVITY = 180f;

        public float Aspect;

        // Position vars
        public TKMathVector3 position;
        public TKMathVector3 rotation;




        private void InputController()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = new MouseState();
            float speed = 0;
            float ugol = rotation.Z / 180 * (float)Math.PI;

            if (keyboardState.IsKeyDown(Key.W))
            {
                speed = -SPEED;
            }
            if (keyboardState.IsKeyDown(Key.S))
            {
                speed = SPEED;
            }
            if (keyboardState.IsKeyDown(Key.A))
            {
                speed = SPEED;
                ugol += (float)Math.PI * 0.5f;
            }
            if (keyboardState.IsKeyDown(Key.D))
            {
                speed = SPEED;
                ugol -= (float)Math.PI * 0.5f;
            }

            if (keyboardState.IsKeyDown(Key.Up))
            {
                rotation.X -= SPEED;
            }
            if (keyboardState.IsKeyDown(Key.Down))
            {
                rotation.X += SPEED;
            }
            if (keyboardState.IsKeyDown(Key.Right))
            {
                rotation.Z += SPEED;
            }
            if (keyboardState.IsKeyDown(Key.Left))
            {
                rotation.Z -= SPEED;
            }

            if (speed != 0)
            {
                position.X += (float)Math.Sin(ugol) * speed;
                position.Y += (float)Math.Cos(ugol) * speed;
            }

        }

        public TKMatrix4 GetProjectionMatrix()
        {
            return TKMatrix4.CreatePerspectiveFieldOfView((float)Math.PI * (45 / 180f), Aspect, 1.0f, 10000.0f);
        }

        public void Update()
        {
         
            GL.Rotate(rotation.X, 1, 0, 0);
            GL.Rotate(rotation.Z, 0, 0, 1);
            GL.Translate(position.X, position.Y, position.Z);
            Console.WriteLine(position);
            InputController();
        }

    }
}
