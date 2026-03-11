using System;

class Program
{
    static void Main()
    {
	    var difficulty = "easy";
	    var logs = true;
		//random debug from when i was lost, might be usefull sometimes
        if (logs) {Console.WriteLine("program.cs called!");}
		
        int defaultTigers = 0;
        int defaultPandas = 0;
        int defaultLions = 0;
        
        int defaultmeat = 0;
        int defaultseeds = 0;
        
        
        
        // init default values
        //init the number of animals at the start of the game
        Console.WriteLine(difficulty);
        if (difficulty != "easy") {
	        defaultTigers = 3;
	        defaultPandas = 2;
	        defaultLions  = 4;
	        defaultmeat = 5;
	        defaultseeds = 6;
        } 
        Console.WriteLine("aaaa");
        
        
        
        
		// create new Animals...   -- 	name|age|gender|ispregnant|isalive|cost|illness
		for (int i = 0; i < defaultTigers; i++)
			new Animals("Tiger", 120, "male", false, true, 0, "false");

		for (int i = 0; i < defaultPandas; i++)
			new Animals("Panda", 60, "female", false, true, 0, "false");

		for (int i = 0; i < defaultLions; i++)
			new Animals("Lion", 95, "male", false, true, 0, "false");

		
	    // create new Food     --    Name|qty|price
	    new Food("meat", defaultmeat, 5);
	    new Food("seeds", defaultseeds, 2.5);

	    
	    
	    if (logs) {
		    foreach (var animal in Animals.AllAnimals)
			    animal.ShowInfos();
		    
		    foreach (var food in Food.AllFoods)
			    food.ShowInfos();
	    }
	    
	    
		//BANK
	    //add money
	    Bank.bankaccount.AddMoney(500); 
	    //remove money
	    Bank.bankaccount.RemoveMoney(200);
	    //show available money
	    Bank.bankaccount.ShowInfos();
	    
	    
	    ///start menu....
	    ///Menu.Start();


    }
}