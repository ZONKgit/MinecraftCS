using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Drawing.Imaging;


namespace Minecraft.Classes
{
    public class BlockRenderer
    {
        // Transforms var
        public Vector3 position;
        public Vector3 scale;

        public bool useTexture = true;

        public Chunk chunk;

        // UV Coords vars
        Vector4 Side1UV = new Vector4(0, 0, 1, 1);
        Vector4 Side2UV = new Vector4(0, 0, 1, 1);
        Vector4 Side3UV = new Vector4(0, 0, 1, 1);
        Vector4 Side4UV = new Vector4(0, 0, 1, 1);
        Vector4 Side5UV = new Vector4(0, 0, 1, 1);
        Vector4 Side6UV = new Vector4(0, 0, 1, 1);

        public BlockRenderer(Vector3 pos, Vector3 scale, Vector4 UV1, Vector4 UV2, Vector4 UV3, Vector4 UV4, Vector4 UV5, Vector4 UV6)
        {
            // Load Transforms
            position = pos;
            this.scale = scale;
            // Load UV
            Side1UV = UV1;
            Side2UV = UV2;
            Side3UV = UV3;
            Side4UV = UV4;
            Side5UV = UV5;
            Side6UV = UV6;


            texture = LoadTexture("Assets/Textures/Atlas.png");
        }

        private int texture;

        public int LoadTexture(string file)
        {
            Bitmap bitmap = new Bitmap(file);

            int tex;
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out tex);
            GL.BindTexture(TextureTarget.Texture2D, tex);

            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits(data);


            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return tex;
        }

        public void Update()
        {
            if (useTexture) GL.Enable(EnableCap.Texture2D);
            GL.Begin(BeginMode.Quads);

            Block block;

            block = chunk.GetBlockAtPosition(position / 2 + new Vector3(0, 0, -1));
            if (block == null)
            {
                GL.TexCoord2(Side1UV.X, Side1UV.W); GL.Vertex3(-scale.X + position.X, scale.Y + position.Y, scale.Z + position.Z);
                GL.TexCoord2(Side1UV.X, Side1UV.Y); GL.Vertex3(-scale.X + position.X, scale.Y + position.Y, -scale.Z + position.Z);
                GL.TexCoord2(Side1UV.Z, Side1UV.Y); GL.Vertex3(-scale.X + position.X, -scale.Y + position.Y, -scale.Z + position.Z);
                GL.TexCoord2(Side1UV.Z, Side1UV.W); GL.Vertex3(-scale.X + position.X, -scale.Y + position.Y, scale.Z + position.Z);
            }

            block = chunk.GetBlockAtPosition(position/2 + new Vector3(0, 0, 1));
            if (block == null)
            {
                GL.TexCoord2(Side2UV.X, Side2UV.W); GL.Vertex3(scale.X + position.X, scale.Y + position.Y, scale.Z + position.Z);
                GL.TexCoord2(Side2UV.X, Side2UV.Y); GL.Vertex3(scale.X + position.X, scale.Y + position.Y, -scale.Z + position.Z);
                GL.TexCoord2(Side2UV.Z, Side2UV.Y); GL.Vertex3(scale.X + position.X, -scale.Y + position.Y, -scale.Z + position.Z);
                GL.TexCoord2(Side2UV.Z, Side2UV.W); GL.Vertex3(scale.X + position.X, -scale.Y + position.Y, scale.Z + position.Z);
            }

            block = chunk.GetBlockAtPosition(position/2 + new Vector3(1, 0, 0));
            if (block == null)
            {
                GL.TexCoord2(Side3UV.X, Side3UV.W); GL.Vertex3(scale.X + position.X, -scale.Y + position.Y, scale.Z + position.Z);
                GL.TexCoord2(Side3UV.X, Side3UV.Y); GL.Vertex3(scale.X + position.X, -scale.Y + position.Y, -scale.Z + position.Z);
                GL.TexCoord2(Side3UV.Z, Side3UV.Y); GL.Vertex3(-scale.X + position.X, -scale.Y + position.Y, -scale.Z + position.Z);
                GL.TexCoord2(Side3UV.Z, Side3UV.W); GL.Vertex3(-scale.X + position.X, -scale.Y + position.Y, 1.0 + position.Z);
            }

            block = chunk.GetBlockAtPosition(position/2 + new Vector3(-1, 0, 0));
            if (block == null)
            {
            GL.TexCoord2(Side4UV.X, Side4UV.W); GL.Vertex3(scale.X + position.X, scale.Y + position.Y, 1.0 + position.Z);
            GL.TexCoord2(Side4UV.X, Side4UV.Y); GL.Vertex3(scale.X + position.X, scale.Y + position.Y, -1.0 + position.Z);
            GL.TexCoord2(Side4UV.Z, Side4UV.Y); GL.Vertex3(-scale.X + position.X, scale.Y + position.Y, -scale.Z + position.Z);
            GL.TexCoord2(Side4UV.Z, Side4UV.W); GL.Vertex3(-scale.X + position.X, scale.Y + position.Y, scale.Z + position.Z);
            }
            
            block = chunk.GetBlockAtPosition(position/2 + new Vector3(0, 1, 0));
            if (block == null)
            {//
                GL.TexCoord2(Side5UV.X, Side5UV.W); GL.Vertex3(scale.X + position.X, scale.Y + position.Y, -scale.Z + position.Z);
                GL.TexCoord2(Side5UV.X, Side5UV.Y); GL.Vertex3(scale.X + position.X, -scale.Y + position.Y, -scale.Z + position.Z);
                GL.TexCoord2(Side5UV.Z, Side5UV.Y); GL.Vertex3(-scale.X + position.X, -scale.Y + position.Y, -scale.Z + position.Z);
                GL.TexCoord2(Side5UV.Z, Side5UV.W); GL.Vertex3(-scale.X + position.X, scale.Y + position.Y, -scale.Z + position.Z);
            }



            block = chunk.GetBlockAtPosition(position/2 + new Vector3(0, -1, 0));
            if (block == null)
            {
            GL.TexCoord2(Side6UV.X, Side6UV.W); GL.Vertex3(scale.X + position.X, scale.Y + position.Y, scale.Z + position.Z);
            GL.TexCoord2(Side6UV.X, Side6UV.Y); GL.Vertex3(scale.X + position.X, -scale.Y + position.Y, scale.Z + position.Z);
            GL.TexCoord2(Side6UV.Z, Side6UV.Y); GL.Vertex3(-scale.X + position.X, -scale.Y + position.Y, scale.Z + position.Z);
            GL.TexCoord2(Side6UV.Z, Side6UV.W); GL.Vertex3(-scale.X + position.X, scale.Y + position.Y, scale.Z + position.Z);
            }  
            
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            
        }
    }
}
