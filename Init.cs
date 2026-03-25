using System;

public static class Init
{
	public static Shop myShop = new Shop("Zoo Store");

public static void initShop(){
    myShop.Items.Clear();
    // Animaux 
    myShop.AddItem("Tigre", 3000);
    myShop.AddItem("Aigle", 1000);
    
    // Habitats
    myShop.AddItem("Habitat Tigre", 2000);
    myShop.AddItem("Habitat Aigle", 1000);
    
    // Food
    myShop.AddItem("Viande (10kg)", 50);
}

    public static void StartGame() {
        initShop();
        
        // init food
        new Food("meat", 50, 5);
        new Food("seeds", 50, 2.5);

        // init tigers
        new Animals("Tiger", 48, "Male", false, true, 3000, "false");
        new Animals("Tiger", 48, "Female", false, true, 3000, "false");

        Console.WriteLine("Bienvenue dans votre Zoo !");
        Game.Play();
    }
}