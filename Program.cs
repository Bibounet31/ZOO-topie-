using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("program.cs called!");
        
        
        Variables.Init();
        Console.WriteLine("nbr de tigres: " + Variables.annimaux["Tigre"]); 
        Console.WriteLine("nbr de Poule: " + Variables.annimaux["Poule"]);
        Console.WriteLine("nbr de Coq: " + Variables.annimaux["Coq"]);
        Console.WriteLine("nbr de Aigle: " + Variables.annimaux["Aigle"]); 
//nouriture
        Console.WriteLine("nouriture:viande " + Variables.nouriture["Viande"]);
    }
}