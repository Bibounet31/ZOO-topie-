using System;

class Program
{
    static void Main()
    {
		///start menu....
	    ///Menu.Start();
	    
		//random debug from when i was lost, might be usefull sometimes
        Console.WriteLine("program.cs called!");
		
        //init the number of animals at the start of the game
        var defaultTigers = 3;
        var defaultPandas = 2;
        var defaultLions  = 4;
        
		// create new Animals... (calling Public Animals in Animals.cs right >:3)	
		//name|age|gender|ispregnant|isalive|cost
		for (int i = 0; i < defaultTigers; i++)
			new Animals("Tiger", 120, "male", false, true, 200, "false");

		for (int i = 0; i < defaultPandas; i++)
			new Animals("Panda", 60, "female", false, true, 300, "false");

		for (int i = 0; i < defaultLions; i++)
			new Animals("Lion", 95, "male", false, true, 150, "false");
		
		
		foreach (var animal in Animals.AllAnimals)
			animal.ShowInfos();

			
	    // create new Food --    Name|qty|price
	    Food viande = new Food("Viande",5,10.5);

		// uses the objects we created: tiger,chicken..... and calling ShowInfos on it
		//Animals
		//tiger.ShowInfos();
		//chicken.ShowInfos();
		//eagle.ShowInfos();

		Console.WriteLine("");
		
		///Food
		viande.ShowInfos();

    }
}