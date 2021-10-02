using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg001
{
    class Battle
    {
        public static void InBattle(Player _Player)
        {
            //Console.WriteLine("아직 개장하지 않았습니다.");
            //Console.ReadKey();
            Monster Mob = new Monster("Monster", 100, 1000, 1000);
            ConsoleKeyInfo CKI;
            while (!Mob.IsDead() && !_Player.IsDead())
            {
                Console.Clear();
                _Player.StatusRender();
                Mob.StatusRender();
                Console.WriteLine("1. 공격한다.");
                Console.WriteLine("2. 도망간다.");
                CKI = Console.ReadKey();
                Console.WriteLine("");

                switch (CKI.Key)
                {
                    case ConsoleKey.D1:
                        _Player.Damage(Mob);
                        if (!Mob.IsDead())
                            Mob.Damage(_Player);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("안전하게 도망쳤다!");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("잘못된 선택입니다.");
                        break;
                }

            }
            Console.WriteLine("");
            Console.WriteLine("싸움이 끝났습니다.");
            if (_Player.IsDead())
            {
                Console.WriteLine("패배 했습니다.");
            }
            else
            {
                Console.WriteLine("승리 했습니다.");
            }
            Console.ReadKey();
            return;
        }
    }
    
}
