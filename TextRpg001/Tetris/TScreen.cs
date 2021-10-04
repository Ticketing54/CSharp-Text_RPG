using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TETRISSCREEN
    {
        protected List<List<string>> BlockList = new List<List<string>>();
        public TETRISSCREEN(int _X, int _Y, bool TopAndBotton)
        {
            for (int y = 0; y < _Y; y++)
            {
                BlockList.Add(new List<string>());
                for (int x = 0; x < _X; x++)
                {
                    BlockList[y].Add("□");
                }
            }

            if (TopAndBotton == false)
                return;

            for (int i = 0; i < BlockList[0].Count; i++)
            {
                BlockList[0][i] = "▣";
            }
            for (int i = 0; i < BlockList[BlockList.Count - 1].Count; i++)
            {
                BlockList[BlockList.Count - 1][i] = "▣";
            }
        }
        
        public int X { get { return BlockList[0].Count; } }
        public int Y { get { return BlockList.Count; } }
        public void SetBlock(int _y, int _x, string _Type)
        {
            BlockList[_y][_x] = _Type;
        }
        public bool IsBlock(int _y, int _x, string _Type)
        {
            return BlockList[_y][_x] == _Type;
        }
        public virtual void Render()
        {
            for (int y = 0; y < BlockList.Count; y++)
            {
                for (int x = 0; x < BlockList[y].Count; x++)
                {
                    Console.Write(BlockList[y][x]);

                }
                Console.WriteLine("");
            }
        }
        public void Clear()
        {
            for (int y = 0; y < BlockList.Count; y++)
            {
                for (int x = 0; x < BlockList[y].Count; x++)
                {
                    if (y == 0 || y == BlockList.Count -1)
                    {
                        BlockList[y][x] = "▣";
                        continue;
                    }
                    BlockList[y][x] = "□";
                }
            }
        }
        
    }

}
