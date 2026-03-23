using System;

class Program
{
    static void Main()
    {
        //random debug from when i was lost, might be usefull sometimes
        if (Settings.Logs) {Console.WriteLine("Program.cs called!");}


        ///start menu....
        ///Menu.Start();
		Shop myShop = new Shop("General Store");
		// Calling it
		myShop.AddItem("Sword", 49.99);
		myShop.AddItem("Potion", 9.99);
		myShop.ShowInventory();
    }
}