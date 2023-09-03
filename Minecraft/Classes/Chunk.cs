using System;
using OpenTK;

namespace Minecraft.Classes
{
    public class Chunk
    {
        public const int ChunkSize = 16; // Размер чанка (по умолчанию 16x16x16)

        private Block[,,] blocks;

        public void Update()
        {
            for (int x = 0; x < ChunkSize; x++)
            {
                for (int y = 0; y < ChunkSize; y++)
                {
                    for (int z = 0; z < ChunkSize; z++)
                    {
                        if (blocks[x, y, z] != null)
                        {
                            blocks[x, y, z].Update();
                        }
                    }
                }
            }
        }

        public Chunk(int chunkX, int chunkZ)
        {
            blocks = new Block[ChunkSize, ChunkSize, ChunkSize];
            
            for (int x = 0; x < ChunkSize; x++)
            {
                for (int y = 0; y < ChunkSize; y++)
                {
                    for (int z = 0; z < ChunkSize; z++)
                    {
                        float worldX = chunkX * ChunkSize + x;
                        float worldZ = chunkZ * ChunkSize + z;

                        float height = 10f * (float)Math.Sin(x * 0.1f) + 10f * (float)Math.Sin(z * 0.1f);
                        // Определите блок на основе высоты
                        if (y < height)
                        {
                            blocks[x, y, z] = new Block(0, x*2, y*2, z*2); // Здесь можно определить блок для земли или других элементов ландшафта
                        }
                        else
                        {
                            blocks[x, y, z] = null; // Здесь можно определить пустой блок (воздух)
                        }
                    }
                }
            }
        }
    }

}

