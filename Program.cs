using System;

class Program
{
    static void Main()
    {
		///start menu....
	    ///Menu.Start();
	    
		//random debug from when i was lost, might be usefull sometimes
        Console.WriteLine("program.cs called!");


		// create new Animals... (calling Public Animals in Animals.cs right >:3)	
								//name|age|gender|ispregnant|isalive|cost
	    Animals tiger = new Animals("Tiger",120,"male",false,false, 200,"false");
	    Animals chicken = new  Animals("Chicken",10,"female",false,false,200,"false");
	    Animals eagle = new Animals("Eagle",15,"female",false,false,200,"malade");
			
	    // create new Food --    Name|qty|price
	    Food viande = new Food("Viande",5,10.5);

		// uses the objects we created: tiger,chicken..... and calling ShowInfos on it
		//Animals
		tiger.ShowInfos();
		chicken.ShowInfos();
		eagle.ShowInfos();

		Console.WriteLine("");
		
		///Food
		viande.ShowInfos();

    }
}