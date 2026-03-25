using System;
using System.Linq;

public static class Game
{
    public static void Play()
    {
        bool playing = true;
        
        while (playing)
        {
            Console.Clear();
            UI.Banner($"{Settings.Name.ToUpper()}");
            
            UI.WriteLine($"  {UI.Yellow}Argent : {Bank.ShowMoney():F2}€{UI.Reset}");
            UI.WriteLine($"  {UI.LightGreen}Animaux : {Animals.AllAnimals.Count(a => a.Isalive)}{UI.Reset}");
            UI.Rule('─', 40);
            
            UI.Option("1", "Passer le mois (Tour Suivant)");
            UI.Option("2", "Voir l'état des animaux");
            UI.Option("3", "Aller à la Boutique");
            UI.Option("4", "Sauvegarder la partie");
            UI.Option("5", "Quitter");
            
            string choix = UI.Prompt();
            switch (choix)
            {
                case "1":
                    UI.Loading("Simulation du mois en cours", 15);
                    Turn.Next();
                    UI.Pause();
                    break;
                case "2":
                    ShowAnimalsStatus();
                    break;
                case "3":
                    OpenShop();
                    break;
                case "4":
                    Saves.Save(1); 
                    break;
                case "5":
                    playing = false;
                    break;
            }
        }
    }

    private static void ShowAnimalsStatus()
    {
        Console.Clear();
        UI.Banner("REGISTRE DES ANIMAUX");
        var aliveAnimals = Animals.AllAnimals.Where(a => a.Isalive).ToList();
        
        if (aliveAnimals.Count == 0) {
            UI.Error("Votre zoo est vide...");
        } else {
            foreach (var animal in aliveAnimals) {
                animal.ShowInfos();
            }
        }
        UI.Pause();
    }

    private static void OpenShop()
    {
        bool inShop = true;
        while (inShop)
        {
            Console.Clear();
            UI.Banner("BOUTIQUE DU ZOO");
            Init.myShop.ShowInventory();
            
            string choiceStr = UI.Prompt("Numéro de l'article (0 pour sortir)");
            if (int.TryParse(choiceStr, out int choice))
            {
                if (choice == 0) {
                    inShop = false;
                } else {
                    Init.myShop.BuyItem(choice);
                    UI.Pause();
                }
            }
        }
    }
}