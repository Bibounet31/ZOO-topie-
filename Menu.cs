using System;

class Menu
{
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
            Console.WriteLine("4 - Quitté le jeu");
            Console.Write("Choix");
            
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
            Console.Write("Choix");

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
            Console.Write("Choix");

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
            Console.WriteLine("4 - retour");
            Console.Write("Choix");

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
    static void Pause()
    {
        Console.WriteLine("\nAppuyer sur Entré");
        Console.ReadLine();
    }

    static void ModeFacile()
    {
        Console.WriteLine("Mode facile");
        Console.ReadLine();
    }

    static void ModeDifficile()
    {
        Console.WriteLine("Mode difficile");
        Console.ReadLine();
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
}