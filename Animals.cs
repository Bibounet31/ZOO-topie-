using System;
using System.Collections.Generic;

class Animals {
    public static List<Animals> AllAnimals = new List<Animals>();	
    public int GestationMonths { get; set; } = 0;
    
    private string _name;
    private int _age;
    private string _gender;
    private bool _ispregnant;
    private bool _isalive;   
    private double _cost;
    private string _illness;
    
    public Animals(string name, int age, string gender, bool ispregnant, bool isalive, double cost, string illness) {
        _name = name; _age = age; _gender = gender; _ispregnant = ispregnant; 
        _isalive = isalive; _cost = cost; _illness = illness;  
        AllAnimals.Add(this);
    }
    
    public string Name { get => _name; set => _name = value; }
    public int Age { get => _age; set => _age = value; }
    public string Gender { get => _gender; set => _gender = value; }
    public bool Ispregnant { get => _ispregnant; set => _ispregnant = value; }
    public bool Isalive { get => _isalive; set => _isalive = value; }
    public double Cost { get => _cost; set => _cost = value; }
    public string Illness { get => _illness; set => _illness = value; }

    public void ShowInfos()
    {
        string color = Isalive ? UI.White : UI.Red;
        string icon = (Gender == "Male") ? "♂" : "♀";
        string preg = Ispregnant ? $"{UI.LightGreen}[Enceinte]{UI.Reset}" : "";
        string sick = Illness != "false" ? $"{UI.Orange}[Malade]{UI.Reset}" : "";

        UI.WriteLine($"  {color}{Name.PadRight(10)}{UI.Reset} | {Age} mois | {icon} | {preg} {sick}");
    }
}