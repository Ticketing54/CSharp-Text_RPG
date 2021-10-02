using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg001
{
    class FightUnit
    {
        protected string Name = "Player";
        protected int AT = 10;
        protected int HP = 50;
        protected int MAXHP = 100;

        public virtual void StatusRender()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"{Name}");
            Console.WriteLine($"공격력 : {AT}");
            Console.WriteLine($"체력 : {HP} / {MAXHP}");
            Console.WriteLine("---------------------------------------");
        }
        public virtual int ReturnAT() { return AT; }
        public void Damage(FightUnit _Target)
        {
            _Target.HP -= ReturnAT();
            Console.WriteLine($"{Name}이 {_Target.Name}에게 {ReturnAT()}의 데미지를 입혔다!");

        }
        public bool IsDead()
        {
            return HP <= 0;
        }
    }

}
