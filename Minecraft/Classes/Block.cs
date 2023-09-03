using System;
using OpenTK;

namespace Minecraft.Classes
{
    class Block
    {
        public int id = 0;
        Vector3 position;
        BlockRenderer render = new BlockRenderer(new Vector3(0, 0, 0), new Vector3(1f, 1f, 1f), 
            new Vector4(0.1875f, 0, 0.25f, 0.0625f),    //Front
            new Vector4(0.1875f, 0, 0.25f, 0.0625f),    //Back
            new Vector4(0, 0.1875f, 0.0625f, 0.25f),    //Left
            new Vector4(0.1875f, 0, 0.25f, 0.0625f),    //Right
            new Vector4(0, 0, 0.0625f, 0.0625f),               //UP
            new Vector4(0.125f, 0, 0.1875f, 0.0625f)                //Down
            );

        public Block(int id = 0, float posX = 0, float posY = 0, float posZ = 0)
        {
            this.id = id;
            position.X = posX;
            position.Y = posY;
            position.Z = posZ;
        }

        public void Update()
        {
            render.position = position;
            render.Update();
        }
    }
}
