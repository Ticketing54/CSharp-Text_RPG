using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg001
{
    class Inven
    {
        Item[] ArrItem;
        Item Equip;
        int ItemX, ItemY, MaxNum;
        int SelectItem = 0;
        public Inven(int _X, int _Y)
        {
            if (_X < 1) _X = 1;
            if (_Y < 1) _Y = 1;
            ItemX = _X;
            ItemY = _Y;
            MaxNum = _X * _Y;
            ArrItem = new Item[(MaxNum)];
        }
        
        void EquipMent(Player _Player,Item _Item)
        {
            if (_Item == null)
                return;

            if (Equip == null)
            {
                Equip = _Item;               
            }                
            else
            {
                Equip.Equip();
                Equip = _Item;
            }
            _Player.Weapon = _Item.AT;
            _Item.Equip();
        }
        void SelectMoveLeft()
        {
            SelectItem--;
            if (SelectItem < 0)
                SelectItem = MaxNum - 1;
        }
        void SelectMoveRight()
        {
            SelectItem++;
            if (SelectItem > MaxNum - 1)
                SelectItem = 0;
        }
        void SelectMoveUp()
        {
            SelectItem -= ItemX;
            if (SelectItem < 0)
                SelectItem = MaxNum + SelectItem;
        }
        void SelectMoveDown()
        {
            SelectItem += ItemX;
            if (SelectItem > MaxNum - 1)
                SelectItem = SelectItem - MaxNum;
        }
        void PrintItem()
        {
            Console.WriteLine("");
            Console.WriteLine("현재 선택한 아이템");
            Console.WriteLine($"이름 : {ArrItem[SelectItem].Name}");
            Console.WriteLine($"가격 : {ArrItem[SelectItem].Gold}");
        }
        void PrintInven()
        {            
            for (int i = 0; i < ArrItem.Length; i++)
            {
                if (i % ItemX == 0 && i != 0)
                    Console.WriteLine("");

                if (SelectItem == i)
                    Console.Write("▣");
                else if (ArrItem[i] == null)
                    Console.Write("□");
                else
                    Console.Write("■");
            }
            Console.WriteLine("");
            if (ArrItem[SelectItem] != null)
            {
                PrintItem();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("비어있음");
            }
        }
        public void Render(Player _Player)
        {
            SelectItem = 0;
            while (true)
            {
                Console.Clear();
                _Player.StatusRender();
                Console.WriteLine("");
                PrintInven();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.RightArrow:
                        SelectMoveRight();
                        break;
                    case ConsoleKey.LeftArrow:
                        SelectMoveLeft();
                        break;
                    case ConsoleKey.UpArrow:
                        SelectMoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        SelectMoveDown();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Enter:
                        EquipMent(_Player, ArrItem[SelectItem]);
                        break;
                    default:
                        break;
                }
                

            }

        }
        public void ItemIn(Item _Item)
        {
            for (int i = 0; i < ArrItem.Length; i++)
            {
                if (ArrItem[i] == null)
                {
                    ArrItem[i] = _Item;
                    break;
                }

            }

        }
        public void ItemIn(Item _Item, int _Order)
        {
            if (_Order > MaxNum - 1)
            {
                Console.WriteLine("존재하지 않은 인벤토리 번호입니다.");
                return;
            }

            if (ArrItem[_Order] != null)
            {
                ItemIn(_Item);
            }
            else
                ArrItem[_Order] = _Item;

        }
    }
}
