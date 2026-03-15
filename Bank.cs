using System;

class Bank
{
    // declaring variables
    public static Bank bankaccount = new Bank(80000);   
    private int _money;

    //constructor
    public Bank(int money) {
        Money = money;
    }


    public void AddMoney(int amount) {
        _money = _money + amount;
    }

    public void RemoveMoney(int amount) {
		if (Settings.Logs) {
			Console.WriteLine($"removed {amount}€ from player");
			}
        _money = _money - amount;
    }
    
    
    
    public int Money {
        get { return _money; }
        set { _money = value; }
    }

    
    
    public void ShowInfos() {
        Console.WriteLine($"{Money}€");
    }
    
    
    
    
}