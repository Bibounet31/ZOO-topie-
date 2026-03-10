using System;


class Menu
{
    static string nomZoo;
    
    public static void Start()
    {
        bool continuer = true ;
        while (continuer)
        {
            
            Console.Clear();
            Console.WriteLine("=== BIENVENUE A ZOOtopie ===");
            Console.WriteLine("1 - Nouvelle Partie");
            Console.WriteLine("2 - Charger partie");
            Console.WriteLine("3 - Parametre");
            Console.WriteLine("4 - Quitter le jeu");
            Console.Write("Choix : ");
            
            string? choix = Console.ReadLine();
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
                    continuer = false;
                    break;
                
                default:
                    Console.WriteLine("Choix invalide");
                    Pause();
                    break;
            }
        }

        Console.WriteLine("Au revoir ! A bientot");
    }

    static void NouvellePartie()
    {
        bool retour = false;
        while (!retour)
        {
            Console.Clear();
            Console.WriteLine("== NOUVELLE PARTIE ==");
            Console.WriteLine("1 - Mode facile");
            Console.WriteLine("2 - Mode difficile");
            Console.WriteLine("3 - Retour");
            Console.Write("Choix : ");

            string? choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    ModeFacile();
                    break;
                
                case "2":
                    ModeDifficile();
                    break;
                
                case "3":
                    retour = true;
                    break;
                
                default:
                    Console.WriteLine("Choix invalide");
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
            Console.WriteLine("== CHANGER PARTIE");
            Console.WriteLine("1 - Charger partie 1: nom");
            Console.WriteLine("2 - Charger partie 2: nom");
            Console.WriteLine("3 - Charger partie 3: nom");
            Console.WriteLine("4 - Retour");
            Console.Write("Choix : ");

            string? choix = Console.ReadLine();
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
                    Console.WriteLine("Choix invalide");
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
            Console.WriteLine("== PARAMETRE PARTIE ==");
            Console.WriteLine("1 - Parametre 1");
            Console.WriteLine("2 - Parametre 2");
            Console.WriteLine("3 - Parametre 3");
            Console.WriteLine("4 - Retour");
            Console.Write("Choix : ");

            string? choix = Console.ReadLine();
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
                    Console.WriteLine("Choix invalide");
                    Pause();
                    break;
            }
        }
    }

    static void MenuZoo()
    {
        bool retour = false;
        while (!retour)
        {
            Console.Clear();
            Console.WriteLine("== MENU DU JEU ==");
            Console.WriteLine("1 - Play");
            Console.WriteLine("2 - Info zoo");
            Console.WriteLine("3 - Map zoo");
            Console.WriteLine("4 - Option");
            Console.WriteLine("5 - Retour");
            Console.WriteLine("6 - Retour menu principal")
            Console.Write("Choix : ");

            string choix = Console.ReadLine();
            switch (choix)
            
            {
                case "1":
                    Play();
                    break;
                
                case "2":
                    InfoZoo ();
                    break;
                
                case "3": 
                    MapZoo ();
                    break;
                
                case "4":
                    Option();
                    break;
                
                case "5":
                    retour = true;
                    break;
                
                case "6":
                    retour = true;
                    break;
                
                default:
                    Console.WriteLine("Choix invalide");
                    Pause();
                    break;
            }
        }
            
    }
    
    static void Pause()
    {
        Console.WriteLine("\nAppuyer sur Entré");
        Console.ReadLine();
    }

    static void ModeFacile()
    {
        Console.WriteLine("Mode facile");
        Console.ReadLine();
        NomZoo();
    }

    static void ModeDifficile()
    {
        Console.WriteLine("Mode difficile");
        Console.ReadLine();
        NomZoo();
    }

    static void NomZoo()
    {
        Console.Clear();
        Console.Write("Entrer le nom de votre Zoo : ");
        nomZoo = Console.ReadLine();

        Console.WriteLine($"\nBIENVENU DANS {nomZoo} VOTRE NOUVEAU ZOO !");
        Pause();
        
        MenuZoo();
    }

    static void ChargerPartie1()
    {
        Console.Write("Charger  partie 1");
        Console.ReadLine();
    }

    static void ChargerPartie2()
    {
        Console.Write("Charger partie 2");
        Console.ReadLine();
    }
    
    static void ChargerPartie3()
    {
        Console.Write("Charger partie 3");
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