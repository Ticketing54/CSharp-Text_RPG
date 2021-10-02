using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg001
{
    class Item
    {
        string iName;
        int iGold;
        int iAT;
        bool iEquipMent = false;
        public int AT { get { return iAT; } }
        public void Equip() { iEquipMent = !iEquipMent; }
        public bool Equipment { get { return iEquipMent; } }
        public string Name { get { return iName; } set { iName = value; } }
        public int Gold { get { return iGold; } set { iGold = value; } }
        public Item(string _Name, int _Gold,int _AT=0)
        {
            iName = _Name;
            iGold = _Gold;
            iAT = _AT;
        }
    }
}
