using System;

class Program
{
    static void Main(string[] args)
    {
        Inven newInven = new Inven(4, 3);
        Item newItem = new Item("철검", 10);
        newInven.ItemIn(newItem, 0);
        newInven.ItemIn(newItem, 3);
        newInven.ItemIn(newItem, 5);
        newInven.ItemIn(newItem, 1);
        newInven.Render();
    }
}