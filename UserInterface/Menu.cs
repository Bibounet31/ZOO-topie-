using System;


class Menu
{
    static string nomZoo;
    
    public static void Start()
    {
        bool continuer = true;
        while (continuer)
        {
            Console.Clear();
            Console.WriteLine();
            UI.PrintLogo();
            UI.HeavyRule();
            UI.Subtitle("le zoo de vos rêves — gérez, construisez, survivez.");

            UI.Option("1", "Nouvelle Partie");
            UI.Option("2", "Charger une partie");
            UI.Option("3", "Paramètres");
            UI.Option("4", "Quitter");
            Console.WriteLine();

            string? choix = UI.Prompt();
            switch (choix)
            {
                case "1":
                    NouvellePartie();
                    break;
                
                case "2":
                    ChargerPartie();
                    break;
                
                case "3":
                    Parametre();
                    break;
                
                case "4":
                    Environment.Exit(0);
                    break;
                
                default:
                    UI.Error("Choix invalide, réessayez.");
                    Pause();
                    break;
            }
        }

        Console.Clear();
        UI.TypeWriteLine("\n  À bientôt dans ZOOtopie.\n", 20, UI.LightGreen + UI.Bold);
    }

    static void NouvellePartie()
    {
        while (true)
        {
            Console.Clear();
            UI.Banner("Nouvelle Partie");

            UI.Option("1", "Mode Facile");
            UI.Option("2", "Mode Difficile");
            UI.Option("3", "Retour");
            Console.WriteLine();

            string? choix = UI.Prompt();
            switch (choix)
            {
                case "1":
                    ModeFacile();
                    break;
                
                case "2":
                    ModeDifficile();
                    break;
                
                case "3":
                    Start();
                    break;
                
                default:
                    UI.Error("Choix invalide, réessayez.");
                    Pause();
                    break;
            }
        }
    }
    
    static void ChargerPartie()
    {
        bool retour = false;
        while (!retour)
        {
            Console.Clear();
            UI.Banner("Charger une Partie");

            UI.Option("1", "Partie 1");
            UI.Option("2", "Partie 2");
            UI.Option("3", "Partie 3");
            UI.Option("4", "Retour");
            Console.WriteLine();

            string? choix = UI.Prompt();
            switch (choix)
            {
                case "1":
                    ChargerPartie1();
                    break;
                
                case "2":
                    ChargerPartie2();
                    break;
                
                case "3":
                    ChargerPartie3();
                    break;
                
                case "4":
                    retour = true;
                    break;
                
                default:
                    UI.Error("Choix invalide, réessayez.");
                    Pause();
                    break;
            }
        }     
    }

    static void Parametre()
    {
        bool retour = false;
        while (!retour)
        {
            Console.Clear();
            UI.Banner("Paramètres");

            UI.Option("1", "Paramètre 1");
            UI.Option("2", "Paramètre 2");
            UI.Option("3", "Paramètre 3");
            UI.Option("4", "Retour");
            Console.WriteLine();

            string? choix = UI.Prompt();
            switch (choix)
            {
                case "1":
                    Parametre1();
                    break;  
                
                case "2":
                    Parametre2();
                    break;  
                
                case "3":
                    Parametre3();
                    break;  
                
                case "4":
                    retour = true;
                    break;
                
                default:
                    UI.Error("Choix invalide, réessayez.");
                    Pause();
                    break;
            }
        }
    }
    
    public static void MenuZoo()
    {
        bool retour = false;
        while (!retour)
        {
            Console.Clear();
            UI.Banner($"Zoo : {Settings.Name}");

            UI.Option("1", "Jouer");
            UI.Option("2", "Infos du Zoo");
            UI.Option("3", "Carte du Zoo");
            UI.Option("4", "Options");
            UI.Option("5", "Menu principal");
            Console.WriteLine();

            string? choix = UI.Prompt();
            switch (choix)
            {
                case "1":
                    Game.Play();
                    break;
                
                case "2":
                    InfoZoo();
                    break;
                
                case "3": 
                    MapZoo();
                    break;
                
                case "4":
                    Option();
                    break;
                
                case "5":
                    Askforslot();
                    break;
                
                default:
                    UI.Error("Choix invalide, réessayez.");
                    Pause();
                    break;
            }
        }
    }
    
    
    static void Askforslot()
    {
        bool retour = false;
        while (!retour)
        {
            Console.Clear();
            UI.Banner($"Zoo : {Settings.Name}");

            UI.Option("1", "Slot 1");
            UI.Option("2", "Slot 2");
            UI.Option("3", "Slot 3");
            UI.Option("4", "Retour");
            Console.WriteLine();

            string? choix = UI.Prompt();
            switch (choix)
            {
                case "1":
                    Saves.Save(1);
                    Start();
                    break;
                
                case "2":
                    Saves.Save(2);
                    Start();
                    break;
                
                case "3": 
                    Saves.Save(3);
                    Start();
                    break;
                
                case "4":
                    MenuZoo();
                    break;
                
                default:
                    UI.Error("Choix invalide, réessayez.");
                    Pause();
                    break;
            }
        }
    }
    
    
    
    static void Pause()
    {
        UI.Pause();
    }

    static void ModeFacile()
    {
        Settings.Difficulty = "easy";
        UI.Loading("Initialisation du mode facile");
        Console.WriteLine($"Difficulty {Settings.Difficulty}");
        Init.StartGame();
        Console.ReadLine();
        NomZoo();
    }

    static void ModeDifficile()
    {
        Settings.Difficulty = "hard";
        UI.Loading("Initialisation du mode difficile");
        Console.WriteLine($"Difficulty {Settings.Difficulty}");
        Init.StartGame();
        Console.ReadLine();
        NomZoo();
    }

    static void NomZoo()
    {
        Console.Clear();
        UI.Rule('─', 48);
        Console.WriteLine();
        UI.Write("  Nom de votre zoo  ", UI.Yellow + UI.Bold);
        Console.WriteLine();
        UI.Rule('─', 48);
        Console.WriteLine();
        UI.Write($"  {UI.Green}›{UI.Reset}  ", "");
        Settings.Name = Console.ReadLine();

        UI.Success($"Bienvenue dans {Settings.Name}.");
        Pause();
        MenuZoo();
    }

    static void ChargerPartie1()
    {
        UI.Loading("Chargement de la partie 1");
        Saves.Load(1);
        Console.ReadLine();
    }

    static void ChargerPartie2()
    {
        UI.Loading("Chargement de la partie 2");
        Saves.Load(2);
        Console.ReadLine();
    }
    
    static void ChargerPartie3()
    {
        UI.Loading("Chargement de la partie 3");
        Saves.Load(3);
        Console.ReadLine();
    }

    static void Parametre1()
    {
        Console.Write("Parametre 1");
        Console.ReadLine();
    }

    static void Parametre2()
    {
        Console.Write("Parametre 2");
        Console.ReadLine();
    }

    static void Parametre3()
    {
        Console.Write("Parametre 3");
        Console.ReadLine();
    }

    static void Play()
    {
        Console.Write("Play");
        Console.ReadLine();
    }

    static void InfoZoo()
    {
        Console.Write("Info Zoo");
        Console.Write(Settings.Name);
        Console.ReadLine();
    }

    static void MapZoo()
    {
        Console.Write("Map Zoo");
        Console.ReadLine();
    }

    static void Option()
    {
        Console.Write("Option");
        Console.ReadLine();
    }
}