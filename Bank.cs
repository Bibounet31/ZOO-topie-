using System;

class Bank
{
    // declaring variables
    public static Bank bankaccount = new Bank(80000);   
    private static double _money;

    //constructor
    public Bank(int money) {
        Money = money;
    }


    public void AddMoney(double amount) {
        _money = _money + amount;
    }

    public void RemoveMoney(double amount) {
		if (Settings.Logs) {
			Console.WriteLine($"removed {amount}€ from player");
			}
        _money = _money - amount;
    }

    public static double ShowMoney()
    {
        return _money;
    }
    
    
    public double Money {
        get { return _money; }
        set { _money = value; }
    }

    
    
    public void ShowInfos() {
        Console.WriteLine($"{Money}€");
    }
    
    
    
    
}