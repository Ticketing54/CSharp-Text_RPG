using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg001
{
    enum STARTSELECT
    {
        SELECTBATTLE,
        SELECTTOWN,
        NONSELECT
    }

    class Program
    {      
        static void Main(string[] args)
        {
            Player NewPlayer = new Player("Player",100,5000,5000);
            Item newitem = new Item("철검", 100, 1);
            Item newitem1 = new Item("곤봉", 100, 2);
            Item newitem2 = new Item("연필", 100, 3);
            Item newitem3 = new Item("책상", 100, 4);
            Item newitem4 = new Item("가방", 100, 5);
            NewPlayer.MyInven.ItemIn(newitem);
            NewPlayer.MyInven.ItemIn(newitem1);
            NewPlayer.MyInven.ItemIn(newitem2);
            NewPlayer.MyInven.ItemIn(newitem3);
            NewPlayer.MyInven.ItemIn(newitem4);

            while (true)
            {
                STARTSELECT SelectCheck = Menu.StartSelect();

                switch (SelectCheck)
                {
                    case STARTSELECT.SELECTTOWN:
                        Town.InTown(NewPlayer);
                        break;
                    case STARTSELECT.SELECTBATTLE:
                        Battle.InBattle(NewPlayer);
                        break;
                }
            }
        }
    }
}
