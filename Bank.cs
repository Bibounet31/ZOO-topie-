class Bank
{
    // declaring variables
    public static Bank bankaccount = new Bank(1000);   
    private int _money;

    //constructor
    public Bank(int money) {
        Money = money;
    }

    
    
    public int Money {
        get { return _money; }
        set { _money = value; }
    }

    
    
    public void ShowInfos() {
        Console.WriteLine(Money);
    }
    
}