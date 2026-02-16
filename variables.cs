using System.Collections.Generic;
using System;

class Variables {
    public static Dictionary<string, int> annimaux;
    public static Dictionary<string, int> nouriture;
    
    
    
    
    
    public static void Init()
    {
        Console.WriteLine("init in variables.cs called");
        annimaux = new Dictionary<string, int>{
            { "Tigre", 1 },
            { "Poule", 2 },
            { "Coq", 3 },
            { "Aigle", 4 },
        };
        
        nouriture = new Dictionary<string, int>{
            { "Viande", 10 },
            { "Graines", 20 }
        };
        
        
    }
}