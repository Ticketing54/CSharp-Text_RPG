using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg001
{
    class Menu
    {
        public static STARTSELECT StartSelect()
        {
            Console.Clear();
            Console.WriteLine("1. 마을");
            Console.WriteLine("2. 배틀");
            Console.WriteLine("어디로 가시겠습니까?");
            ConsoleKeyInfo CKI = Console.ReadKey();
            Console.WriteLine("");
            switch (CKI.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("마을을 선택하셨습니다.");
                    Console.ReadKey();
                    return STARTSELECT.SELECTTOWN;
                case ConsoleKey.D2:
                    Console.WriteLine("배틀을 선택하셨습니다.");
                    Console.ReadKey();
                    return STARTSELECT.SELECTBATTLE;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    Console.ReadKey();
                    return STARTSELECT.NONSELECT;
            }

        }
    }
}
