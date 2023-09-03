using System;
using OpenTK;

namespace Minecraft.Classes
{
    public class World
    {
        private Chunk[,] chunks;

        public void GenerateWorld()
        {
            chunks[0, 0] = new Chunk(0, 0);
        }

        public World()
        {
            chunks = new Chunk[1, 1];
            //GenerateWorld();
        }

        public void Update()
        {
            chunks[0,0].Update();
        }

        //public Block GetBlockAtPosition(Vector3 position)
        //{
        //    // Найдите чанк, в котором находится позиция, и получите блок из чанка
        //    int chunkX = (int)Math.Floor(position.X / Chunk.ChunkSize);
        //    int chunkZ = (int)Math.Floor(position.Z / Chunk.ChunkSize);

        //    // Обработайте граничные условия и верните блок
        //    Block block = chunks[chunkX, chunkZ].GetBlockAtPosition(position);
        //    return block; 
        //}
    }
}
