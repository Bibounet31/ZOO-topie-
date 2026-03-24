using System;

public class RandomGender
{
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

public static class Rng
{
    private static Random _rnd = new Random();

    //returns true with the given probability (0.0 to 1.0)
    public static bool Chance(double probability) {
        return _rnd.NextDouble() < probability;
    }

    //returns a random int between min and max (exclusive)
    public static int Range(int min, int max) {
        return _rnd.Next(min, max);
    }

    //returns a variation multiplier of +/- 20%
    public static double Variation() {
        return 1 + (_rnd.NextDouble() * 0.4 - 0.2);
    }

    //returns a random item from a list
    public static T Pick<T>(System.Collections.Generic.List<T> list) {
        return list[_rnd.Next(list.Count)];
    }
}