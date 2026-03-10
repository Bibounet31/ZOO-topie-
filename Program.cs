using System;

class Program
{
    static void Main()
    {

	    var logs = false;
		//random debug from when i was lost, might be usefull sometimes
        if (logs) {Console.WriteLine("program.cs called!");}
		
        
        // init default values
        //init the number of animals at the start of the game
        var defaultTigers = 3;
        var defaultPandas = 2;
        var defaultLions  = 4;

        var defaultmeat = 5;
        var defaultseeds = 6;
        
        
        
        
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


	    ///start menu....
	    Menu.Start();
		

    }
}