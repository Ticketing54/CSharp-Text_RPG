using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    

    enum BLOCKTYPE
    {
        BT_I,   // 작대기
        BT_L,   // 왼쪽 갈고리
        BT_J,   // 오른쪽 갈고리
        BT_Z,   // 오른쪽 삐뚤이
        BT_S,   // 왼쪽 삐뚤이
        BT_T,   // T모양
        BT_O    // 네모
    }
    class Block
    {
        int X = 0, Y = 0;        
        List<List<string>> BlockData = new List<List<string>>();
        TETRISSCREEN Screen = null;
        public Block(TETRISSCREEN _Screen)
        {
            Screen = _Screen;
            for (int y = 0; y < 4; y++)
            {
                BlockData.Add(new List<string>());
            }
            

        }
        private void InPut()
        {
            if (!Console.KeyAvailable)
                return;            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    X -= 1;
                    break;
                case ConsoleKey.D:
                    X += 1;
                    break;
                case ConsoleKey.S:
                    Y += 1;
                    break;
                default:
                    break;
            }
            
        }
        public void Move()
        {
            InPut();           
            Screen.SetBlock(Y, X, "■");
        }    
        
       

    }
}
