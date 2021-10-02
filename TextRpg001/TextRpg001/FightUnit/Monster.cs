using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg001
{
    class Monster : FightUnit
    {
        public Monster(string _Name, int _AT, int _Hp, int _MaxHp)
        {
            Name = _Name;
            AT = _AT;
            HP = _Hp;
            MAXHP = _MaxHp;
        }
    }
}
