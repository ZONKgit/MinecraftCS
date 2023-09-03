using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Windows.Forms;
using TKMatrix4 = OpenTK.Matrix4; // Псевдоним для OpenTK.Matrix4



namespace Minecraft.Classes
{
    public class Camera
    {
        //Constants
        private float SPEED = 1f;
        private float SENSITIVITY = 180f;

        public GameWindow window;
        public float Aspect;

        // Position vars
        public Vector3 position;
        public Vector3 rotation;


        private void Rotate(float xAngle, float zAngle)
        {
            rotation.Z += zAngle;
            if (rotation.Z < 0) rotation.Z += 360;
            if (rotation.Z > 360) rotation.Z -= 360;
            rotation.X -= xAngle;
            if (rotation.X < 0) rotation.X = 0;
            if (rotation.X > 180) rotation.X = 180;
        }

        private void InputController()
        {
            if (!window.Focused) return;
            Cursor.Hide();

            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = new MouseState();
            float speed = 0;
            float ugol = rotation.Z / 180 * (float)Math.PI;

            if (keyboardState.IsKeyDown(Key.W)) speed = SPEED;
            if (keyboardState.IsKeyDown(Key.S)) speed = -SPEED;
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

            if (keyboardState.IsKeyDown(Key.Up)) rotation.X -= SPEED;
            if (keyboardState.IsKeyDown(Key.Down)) rotation.X += SPEED;
            if (keyboardState.IsKeyDown(Key.Right)) rotation.Z += SPEED;
            if (keyboardState.IsKeyDown(Key.Left)) rotation.Z -= SPEED;

            if (speed != 0)
            {
                position.X += (float)Math.Sin(ugol) * speed;
                position.Y += (float)Math.Cos(ugol) * speed;
            }



            int basePosX = 1920 / 2;
            int basePosY = 1080 / 2;
            int mousePosX = Mouse.GetCursorState().X;
            int mousePosY = Mouse.GetCursorState().Y;
            Rotate((basePosY - mousePosY) / 25, (basePosX - mousePosX) /25);
            Mouse.SetPosition(basePosX, basePosY);

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
   
            InputController();
        }

    }
}
