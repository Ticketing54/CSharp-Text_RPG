using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    enum BLOCKDIR
    {
        BD_T,
        BD_R,
        BD_B,
        BD_L,
        BD_MAX

    }

    enum BLOCKTYPE
    {
        BT_I,   // 작대기
        BT_L,   // 왼쪽 갈고리
        BT_J,   // 오른쪽 갈고리
        BT_Z,   // 오른쪽 삐뚤이
        BT_S,   // 왼쪽 삐뚤이
        BT_T,   // T모양
        BT_O,    // 네모
        BT_MAX
            
    }
   
    partial class Block
    {
        int X = 0, Y = 0;
        BLOCKTYPE CurType = BLOCKTYPE.BT_T;
        BLOCKDIR CurDir = BLOCKDIR.BD_T;
        string[][] Arr = null;
        //List<List<string>> BlockData = new List<List<string>>();
        TETRISSCREEN Screen = null;
        public Block(TETRISSCREEN _Screen)
        {
            Screen = _Screen;
            DataInit();

            SettingBlock(BLOCKTYPE.BT_T, BLOCKDIR.BD_T);
            
        }
        private BLOCKDIR RotateDir(BLOCKDIR _main)
        {
            
            BLOCKDIR nextDir = ++_main;
            if (nextDir == BLOCKDIR.BD_MAX)
                return BLOCKDIR.BD_T;
            return nextDir;
        }
        private void SettingBlock(BLOCKTYPE _TYPE, BLOCKDIR _Dir)
        {
            Arr = AllBlock[(int)_TYPE][(int)_Dir];
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
                case ConsoleKey.Q:
                    //왼쪽
                    break;
                case ConsoleKey.E:
                    //오른쪽
                    break;
                case ConsoleKey.Spacebar:
                    Dir = RotateDir(Dir);
                    SettingBlock(BLOCKTYPE.BT_T, Dir);
                    break;
                default:
                    break;
            }
            
        }
        public void Move()
        {
            InPut();                       
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (Arr[y][x] == "□")
                    {
                        continue;
                    }                    
                    Screen.SetBlock(Y+y, X+x, Arr[y][x]);
                }
            }
        }    
        
       

    }
}
