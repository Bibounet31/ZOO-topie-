using System;

public static class Game
{
    public static void Play()
    {
        Console.Clear();
        Console.WriteLine("Game starting...");
        
        bool playing = true;
        int turn = 1;
        
        while (playing)
        {
            Console.Clear();
            UI.Banner($"Tour {turn}");
            
            // show some infos
            Console.WriteLine($"Animals: {Animals.AllAnimals.Count(a => a.Isalive)}");
            Bank.bankaccount.ShowInfos();
            
            // player options
            UI.Option("1", "Passer le tour");
            UI.Option("2", "Voir les animaux");
            UI.Option("3", "Boutique");
            UI.Option("4", "Quitter");
            
            string? choix = UI.Prompt();
            switch (choix)
            {
                case "1":
                    Turn.Next();
                    turn++;
                    UI.Prompt();
                    break;
                case "2":
                    foreach (var animal in Animals.AllAnimals)
                        animal.ShowInfos();
                    UI.Prompt();
                    break;
                case "3":
                    Init.myShop.ShowInventory();
                    UI.Prompt();
                    break;
                case "4":
                    playing = false;
                    break;
            }
        }
    }
}