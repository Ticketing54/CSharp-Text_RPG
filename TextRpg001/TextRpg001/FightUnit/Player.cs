using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg001
{
    class Player : FightUnit
    {
        Inven myInven = new Inven(4, 3);
        public Inven MyInven { get { return myInven; } set { myInven = value; } }
        int PWeapon,PGold;
        public int Weapon { get { return PWeapon; }set { PWeapon = value; } }
        public int Gold { get { return PGold; } set { PGold = value; } }
        public Player(string _Name, int _AT, int _Hp, int _MaxHp,int _Weapon=0,int _Gold=0)
        {
            Name = _Name;
            AT = _AT;
            HP = _Hp;
            MAXHP = _MaxHp;
            Weapon = _Weapon;
            Gold = _Gold;

        }
        public override void StatusRender()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"{Name}");
            Console.WriteLine("");
            Console.WriteLine($"공격력 : {AT} + ({Weapon})");
            Console.WriteLine($"체력 : {HP} / {MAXHP}");
            Console.WriteLine("---------------------------------------");
           
        }
        public override int ReturnAT()
        {
            return AT + Weapon;
        }
        public void RecoverHp()
        {            
            if (HP >= MAXHP)
            {
                Console.WriteLine("");
                Console.WriteLine("체력이 모두 회복되어 있어서 회복할 필요가 없습니다.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine($"플레이어의 체력이 {MAXHP - HP}만큼 회복되었습니다.");
                HP = MAXHP;
                Console.ReadKey();
            }

        }
        
    }
}
