using System; // needed for Console.stuff (WriteLine for example) 

class Animals {
    // declaring variables (_ since theyre private)
    private string _name;
    private int _age;
    private string _gender;
    private bool _ispregnant;
    private bool _isalive;   
	private double _cost;
    
    // constructor (note to myself, it must have the same name as the class...)
    public Animals(string name, int age, string gender, bool ispregnant, bool isalive, double cost) {
        Name = name;
        Age = age;
        Gender = gender;
        Ispregnant = ispregnant;
        Isalive = isalive;
		Cost = cost;
    }
    
    // get-set used by constructor to check stuff about the inserted value, can use it to add a condition ( for example : if (value<0){don't});
    // theyre the only way we can edit private variables, 
    // why private ? so we can process the value we want to insert, preventing anyone to insert crap in it
    
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
    
    // ShowInfos uses the infos stored in the "public bool "blabla" that get their values from the private variables on top :3
    public void ShowInfos()
    {
        Console.WriteLine($"Animal : {Name},age: {Age},genre: {Gender},is pregnant: {Ispregnant},is alive: {Isalive}, cost(monthly): {Cost}");
    }
    
}