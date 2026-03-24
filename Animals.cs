using System; // needed for Console.stuff (WriteLine for example) 

class Animals {
	//store created animals!
	public static List<Animals> AllAnimals = new List<Animals>();	
	public int GestationMonths { get; set; } = 0;
	public int IllnessDaysLeft { get; set; } = 0;

    // declaring variables (_ since theyre private)
    private string _name = "";
    private int _age;
    private string _gender = "";
    private bool _ispregnant;
    private bool _isalive;   
	private double _cost;
	private string _illness = "";
    
    // constructor (note to myself, it must have the same name as the class...)
    public Animals(string name, int age, string gender, bool ispregnant, bool isalive, double cost, string illness) {
        Name = name;
        Age = age;
        Gender = gender;
        Ispregnant = ispregnant;
        Isalive = isalive;
		Cost = cost;
		Illness = illness;  

		AllAnimals.Add(this);
    }
    
    // get-set used by constructor to check stuff about the inserted valude, can use it to add a condition ( example : if (value<0){don't});
    // theyre the only way we can edit private variables, 
    // why making the first values private then? it's so we can process the value we want to insert, preventing anyone to insert crap directly in them..
    
    public String Name {
        get { return _name; }
        set { _name = value; }
    }

    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    public String Gender {
        get { return _gender; }
        set { _gender = value; }
    }
    
    public bool Ispregnant {
        get  { return _ispregnant; }
        set { _ispregnant = value; }
    }
    
    public bool Isalive {
        get { return _isalive; }
        set { _isalive = value; }
    }

	public double Cost {
		get { return _cost; }
		set { _cost = value; }
	}
    
	public string Illness {
		get { return _illness; }
		set { _illness = value; }
}

    // ShowInfos uses the infos stored in the "public bool "blabla" that get their values from the private variables on top :3
    public void ShowInfos()
    {
        Console.WriteLine($"Animal : {Name},   age: {Age},    genre: {Gender},   is pregnant: {Ispregnant},   is alive: {Isalive},    cost(monthly): {Cost},    illness {Illness}");
    }
    
}