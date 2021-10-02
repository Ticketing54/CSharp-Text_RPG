using System;
using System.Collections.Generic;
using System.Text;

class Item
{
    string iName;
    int iGold;
    public string Name { get { return iName; } set { iName = value; } }
    public int Gold { get { return iGold; } set { iGold = value; } }
    public Item(string _Name, int _Gold)
    {
        iName = _Name;
        iGold = _Gold;
    }
}