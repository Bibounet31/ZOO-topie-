using System;

public class Food
{
    private string _name;
    private int _quantity;
    private double _price;
    
    public  Food(string name, int quantity, double price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
    
    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    
    public int Quantity {
        get { return _quantity; }
        set { _quantity = value; }
    }
    
    public double Price {
        get { return _price; } 
        set { _price = value; }
    }

    public void ShowInfos() {
        Console.WriteLine($"FOOD:  nom: {Name}, quantity: {Quantity}, price: {Price}");
    }
    
}