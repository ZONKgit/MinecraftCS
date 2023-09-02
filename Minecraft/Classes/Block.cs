using System;
using OpenTK;

namespace Minecraft.Classes
{
    class Block
    {
        int id = 0;
        Vector3 position;
        BlockRenderer render = new BlockRenderer();

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
