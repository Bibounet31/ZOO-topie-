using System;

public static class Init
{
	public static Shop myShop = new Shop("General Store");
	public static void initShop(){
		if (Settings.Difficulty == "easy") {
			if (Settings.Logs) {
				Console.WriteLine("setting up easy shop");
				}
			myShop.AddItem("cow", 49.99);
			myShop.AddItem("chgicken", 9.99);
			myShop.ShowInventory();
		} else {
			if (Settings.Logs) {
				Console.WriteLine("setting up hard shop");
				}
				myShop.AddItem("cow", 49.99);
				myShop.AddItem("chgicken", 9.99);
				myShop.ShowInventory();
		}
	}

    public static void StartGame()
    {
       
        int defaultTiger = 0;
        int defaultPandas = 0;
        int defaultLions = 0;
        
        int defaultmeat = 0;
        int defaultseeds = 0;
        
        // init default values
        //init the number of animals at the start of the game
        Console.WriteLine(Settings.Difficulty);
        if (Settings.Difficulty == "easy") { //difficulty easy
            defaultTiger = 3;
            defaultPandas = 2;
            defaultLions  = 4;
            defaultmeat = 5;
            defaultseeds = 6;
			initShop();
        } else {                // difficulty hard
            defaultTiger = 2;
            defaultPandas = 2;
            defaultLions  = 2;
            defaultmeat = 3;
            defaultseeds = 4;
			initShop();
            Bank.bankaccount.RemoveMoney(20000);
        }
        
       // create new Animals...   --  name|age|gender|ispregnant|isalive|cost|illness
       for (int i = 0; i < defaultTiger; i++) {
          RandomGender rg = new RandomGender(); //get random gender
          new Animals("Tiger", 120, rg.Gender, false, true, 0, "false");
       }

       for (int i = 0; i < defaultPandas; i++) {
          RandomGender rg = new RandomGender();
          new Animals("Panda", 60, rg.Gender, false, true, 0, "false");
       }

       for (int i = 0; i < defaultLions; i++) {
          RandomGender rg = new RandomGender();
          new Animals("Lion", 95, rg.Gender, false, true, 0, "false");
       }

        // create new Food     --    Name|qty|price
        if (defaultmeat > 0 || defaultseeds > 0) {
           new Food("meat", defaultmeat, 5);
           new Food("seeds", defaultseeds, 2.5);
        }
        
        if (Settings.Logs) {
           foreach (var animal in Animals.AllAnimals)
              animal.ShowInfos();
           
           foreach (var food in Food.AllFoods)
              food.ShowInfos();
        }
        


	
       //BANK
        //add money
        //Bank.bankaccount.AddMoney(500); 
        //remove money
        //Bank.bankaccount.RemoveMoney(200);
        //show available money
        //Bank.bankaccount.ShowInfos();
    }
}