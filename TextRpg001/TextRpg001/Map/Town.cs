using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg001
{
    class Town
    {
        public static void Recovery(Player _Player)
        {
            if (_Player.Gold >= 1000)
            {
                _Player.Gold -= 1000;
                _Player.RecoverHp();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("소지금이 부족합니다.");
                Console.ReadKey();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        public static void InTown(Player _Player)
        {
            while (true)
            {
                Console.Clear();
                _Player.StatusRender();
                Console.WriteLine("마을에서 무슨일을 하시겠습니까?");
                Console.WriteLine("1. 체력을 회복한다. ( -1000 Gold )");
                Console.WriteLine("2. 상점에 들어간다.");
                Console.WriteLine("3. 인벤토리를 확인한다.");
                Console.WriteLine("4. 마을을 나간다.");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Recovery(_Player);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("");
                        Console.WriteLine("준비중 입니다...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        _Player.MyInven.Render(_Player);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("");
                        Console.WriteLine("마을을 나갑니다.");
                        Console.ReadKey();
                        return;
                    default:
                        break;
                }
            }

        }
      
    }
    
}
