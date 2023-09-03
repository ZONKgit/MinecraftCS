using System;
using OpenTK;

namespace Minecraft.Classes
{
    public class Chunk
    {
        public const int ChunkSize = 8; // Размер чанка (по умолчанию 16x16x16)

        public Block[,,] blocks;

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

        public Block GetBlockAtPosition(Vector3 position)
        {
            // Найдите блок в чанке по позиции
            int x = (int)position.X;
            int y = (int)position.Y;
            int z = (int)position.Z;

            // Проверка на граничные условия
            if (x >= 0 && x < Chunk.ChunkSize &&
                y >= 0 && y < Chunk.ChunkSize &&
                z >= 0 && z < Chunk.ChunkSize)
            {
                return blocks[x, y, z];
            }
            else
            {
                // Вернуть что-то, что обозначает отсутствие блока (например, пустой блок или null)
                return null;
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
                            Block block = new Block(0, x, y, z);
                            block.render.chunk = this;
                            blocks[x, y, z] = block; // Здесь можно определить блок для земли или других элементов ландшафта
                            Console.WriteLine("X:{0} Y:{1} Z:{2}",x,y,z);
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

