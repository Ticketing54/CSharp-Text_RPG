using System;
using System.Collections.Generic;
using System.Text;

class Inven
{
    Item[] ArrItem;
    int ItemX, ItemY, MaxNum;
    int SelectItem = 0;
    public Inven(int _X,int _Y)
    {
        if (_X < 1) _X = 1;
        if (_Y < 1) _Y = 1;
        ItemX = _X;
        ItemY = _Y;
        MaxNum = _X * _Y;
        ArrItem = new Item[(MaxNum)];
    }   
    public void SelectMoveLeft()
    {
        SelectItem--;
        if (SelectItem < 0)
            SelectItem = MaxNum - 1;
    }
    public void SelectMoveRight()
    {
        SelectItem++;
        if (SelectItem > MaxNum - 1)
            SelectItem = 0;
    }
    public void SelectMoveUp()
    {
        SelectItem -= ItemX;
        if (SelectItem < 0)
            SelectItem = MaxNum + SelectItem;
    }
    public void SelectMoveDown()
    {
        SelectItem += ItemX;
        if (SelectItem > MaxNum - 1)
            SelectItem = SelectItem - MaxNum;
    }
    public void PrintItem()
    {
        Console.WriteLine("");
        Console.WriteLine("현재 선택한 아이템");
        Console.WriteLine($"이름 : {ArrItem[SelectItem].Name}");
        Console.WriteLine($"가격 : {ArrItem[SelectItem].Gold}");
    }
    public void PrintInven()
    {
        Console.Clear();
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
    public void Render()
    {
        SelectItem = 0;
         while (true)
         {            
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
                default:
                    break;
            }
            
         }
        
    }
    public void ItemIn(Item _Item)
    {
        for(int i = 0; i < ArrItem.Length; i++)
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