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
        TKMathVector3 up = TKMathVector3.UnitY;
        TKMathVector3 front = -TKMathVector3.UnitZ;
        TKMathVector3 right = TKMathVector3.UnitX;

        // Rotations
        private float pitch;
        private float yaw = -90.0f;

        private bool firstMove = false;
        public Vector2 lastPosition;

        public TKMathMatrix4 GetViewMatrix()
        {
            return TKMathMatrix4.LookAt(position, position + front, up);
        }
        public TKMatrix4 GetProjectionMatrix()
        {
            return TKMatrix4.CreatePerspectiveFieldOfView((float)Math.PI * (45 / 180f), Aspect, 1.0f, 10000.0f);
        }
        
        private void UpdateVectors()
        {
            front.X = (float)Math.Cos(MathHelper.DegreesToRadians(pitch)) * (float)Math.Cos(MathHelper.DegreesToRadians(yaw));
            front.Y = (float)Math.Sin(MathHelper.DegreesToRadians(pitch));
            front.Z = (float)Math.Cos(MathHelper.DegreesToRadians(pitch)) * (float)Math.Sin(MathHelper.DegreesToRadians(yaw));

            front = TKMathVector3.Normalize(front);
            right = TKMathVector3.Normalize(TKMathVector3.Cross(front, TKMathVector3.UnitY));
            up = TKMathVector3.Normalize(TKMathVector3.Cross(right, front));



        }

        private void InputController()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = new MouseState();

            if (keyboardState.IsKeyDown(Key.W))
            {
                position -= front * SPEED;
            }
            if (keyboardState.IsKeyDown(Key.S))
            {
                position += front * SPEED;
            }
            if (keyboardState.IsKeyDown(Key.A))
            {
                position += right * SPEED;
            }
            if (keyboardState.IsKeyDown(Key.D))
            {
                position -= right * SPEED;
            }
            if (keyboardState.IsKeyDown(Key.LShift))
            {
                position += up * SPEED;
            }
            if (keyboardState.IsKeyDown(Key.Space))
            {
                position -= up * SPEED;
            }

            if (firstMove)
            {
                lastPosition = new Vector2(mouseState.X, mouseState.Y);
                firstMove = false;
            }
            else
            {
                var deltaX = mouseState.X - lastPosition.X;
                var deltaY = mouseState.Y - lastPosition.Y;
                Console.WriteLine(mouseState.X);
                Console.WriteLine(mouseState.Y);
                lastPosition = new Vector2(mouseState.X, mouseState.Y);

                yaw += deltaX * SENSITIVITY;
                pitch += deltaY * SENSITIVITY;
            }
            UpdateVectors();

        }

        public void Update()
        {
            GL.Translate(position.X, position.Y, position.Z);
            InputController();
        }

    }
}
