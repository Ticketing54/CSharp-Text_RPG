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
        ACCSCREEN AccScreen = null;
        Random NewRandom = new Random();
        public Block(TETRISSCREEN _Screen, ACCSCREEN _AccScreen)
        {
            if (_Screen == null || _AccScreen == null)
                return;
            Screen = _Screen;
            AccScreen = _AccScreen;
            DataInit();            
            Reset();
            
        }        
        private void SettingBlock(BLOCKTYPE _TYPE, BLOCKDIR _Dir)
        {
            Arr = AllBlock[(int)_TYPE][(int)_Dir];
        }
        public  void RandomBlockType()
        {
            int Type = NewRandom.Next((int)BLOCKTYPE.BT_I, (int)BLOCKTYPE.BT_MAX);
            //int Type = (int)BLOCKTYPE.BT_I;
            CurType = (BLOCKTYPE)Type;
        }
        public void Reset()
        {
            RandomBlockType();
            X = 0;
            Y = 1;
            SettingBlock(CurType, CurDir);
        }
        public bool DownCheck()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (Arr[y][x] == "■")
                    {
                        if(AccScreen.Y == Y + y || AccScreen.IsBlock(y+Y,x+X, "■"))
                        {
                            SetAccScreen();                            
                            Reset();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public void SetAccScreen()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (Arr[y][x] == "■")
                    {
                        AccScreen.SetBlock(y + Y-1, x + X, Arr[y][x]);
                        
                    }
                }
            }
        }
        public void Down()
        {            
            if (DownCheck())
            {
                return;
            }
            Y += 1;
        }
        private void InPut()
        {
            //Y += 1;
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
                    Down();
                    break;
                case ConsoleKey.Q:
                    --CurDir;
                    if (0 > CurDir)
                        CurDir = BLOCKDIR.BD_L;
                    SettingBlock(CurType, CurDir);
                    break;
                case ConsoleKey.E:
                    ++CurDir;
                    if (BLOCKDIR.BD_MAX == CurDir)
                        CurDir = BLOCKDIR.BD_T;
                    SettingBlock(CurType, CurDir);
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
