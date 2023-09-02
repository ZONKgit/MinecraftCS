using System;
using OpenTK;

namespace Minecraft.Classes
{
    class Block
    {
        int id = 0;
        Vector3 position;
        BlockRenderer render = new BlockRenderer(new Vector3(0, 0, 0), new Vector3(1, 1, 1), 
            new Vector4(0, 0, 1, 1),
            new Vector4(0, 0, 1, 1),
            new Vector4(0, 0, 1, 1),
            new Vector4(0, 0, 1, 1),
            new Vector4(0, 0, 1, 1),
            new Vector4(0, 0, 1, 1)
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
