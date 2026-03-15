using System;

public class RandomGender {
    
    private string _gender = "";

    //constructor
    public RandomGender() {
        Random rnd = new Random();
        int value = rnd.Next(0,2);
        
        if (value == 1) {
            Gender = "Male";
        } else {
            Gender = "Female";
        }
       
    }
    
    
    
    public string Gender 
    {
        get { return _gender; }
        set { _gender = value; }
    }
    
    
}

