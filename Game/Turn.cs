using System;
using System.Collections.Generic;
using System.Linq;

public static class Turn
{
    private static int _currentMonth = 1;
    private static int _currentYear = 1;
    private static int _totalTurns = 0;
    private static int[] _daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    public static void Next() {
        UI.WriteLine($"\n{UI.Bold}{UI.Tan}Rapport de {GetMonthName(_currentMonth)} (An {_currentYear}){UI.Reset}");
        UI.Rule('┄', 30);

        ProcessFeeding();
        ProcessReproduction();
        ProcessAging();
        ProcessIllness();
        ProcessVisitors();
        ProcessSubventions();
        Events.ProcessAll();
        AdvanceMonth();
    }

    private static void ProcessFeeding() {
        int days = _daysInMonth[_currentMonth - 1];
        double meatNeeded = 0;
        double seedsNeeded = 0;

        foreach (var a in Animals.AllAnimals.Where(a => a.Isalive)) {
            double daily = (a.Name.ToLower() == "tiger" ? (a.Gender == "Male" ? 12 : 10) : 0.3);
            if (a.Ispregnant) daily *= 2;
            
            if (a.Name.ToLower() == "tiger") meatNeeded += daily * days;
            else seedsNeeded += daily * days;
        }

        double totalCost = (meatNeeded * 5.0) + (seedsNeeded * 2.5);
        
        if (Bank.ShowMoney() >= totalCost) {
            Bank.bankaccount.RemoveMoney(totalCost);
            UI.WriteLine($"Nourriture : -{totalCost:F2}€");
        } else {
            UI.Error("FAMINE ! Pas assez d'argent pour nourrir les animaux.");
            foreach (var a in Animals.AllAnimals.Where(a => a.Isalive)) {
                if (a.Ispregnant) { a.Ispregnant = false; UI.WriteLine($"{UI.Red}!{UI.Reset} {a.Name} a avorté (faim)."); }
                if (a.Name.ToLower() == "tiger") a.Isalive = false;
            }
        }
    }

    private static void ProcessReproduction() {
        foreach (var female in Animals.AllAnimals.Where(a => a.Isalive && a.Gender == "Female" && !a.Ispregnant)) {
            //  15% de chance si un mâle est présent
            if (Animals.AllAnimals.Any(m => m.Name == female.Name && m.Gender == "Male" && m.Isalive)) {
                if (Rng.Chance(0.15)) {
                    female.Ispregnant = true;
                    UI.WriteLine($"{UI.LightGreen}❤{UI.Reset} {female.Name} est pleine !");
                }
            }
        }

        foreach (var female in Animals.AllAnimals.Where(a => a.Ispregnant)) {
            female.GestationMonths++;
            if (female.GestationMonths >= 3) { 
                female.Ispregnant = false;
                female.GestationMonths = 0;
                new Animals(female.Name, 0, new RandomGender().Gender, false, true, 0, "false");
                UI.WriteLine($"{UI.Yellow}★{UI.Reset} Naissance d'un bébé {female.Name} !");
            }
        }
    }

    private static void ProcessAging() {
        foreach (var a in Animals.AllAnimals.Where(a => a.Isalive)) {
            a.Age++;
            if (a.Age > 180 && Rng.Chance(0.10)) { 
                a.Isalive = false;
                UI.WriteLine($"{UI.Red}†{UI.Reset} {a.Name} est mort de vieillesse.");
            }
        }
    }

    private static void ProcessIllness() {
        foreach (var a in Animals.AllAnimals.Where(a => a.Isalive && a.Illness == "false")) {
            if (Rng.Chance(0.02)) {
                a.Illness = "Malade";
                UI.WriteLine($"{UI.Orange}⚠{UI.Reset} Un {a.Name} est tombé malade !");
            }
        }
    }

    private static void ProcessVisitors() {
        double visitors = Animals.AllAnimals.Count(a => a.Isalive) * 15 * Rng.Variation();
        double money = visitors * 15; // 15€ par visiteur
        Bank.bankaccount.AddMoney(money);
        UI.WriteLine($"Billetterie : +{money:F2}€ ({Math.Round(visitors)} visiteurs)");
    }

    private static void ProcessSubventions() {
        if (_currentMonth == 1) {
            double grant = 5000;
            Bank.bankaccount.AddMoney(grant);
            UI.Success("Subvention annuelle de l'État : +5000€");
        }
    }

    private static void AdvanceMonth() {
        _totalTurns++;
        _currentMonth++;
        if (_currentMonth > 12) { _currentMonth = 1; _currentYear++; }
    }

    private static string GetMonthName(int m) => new[] {"Janvier","Février","Mars","Avril","Mai","Juin","Juillet","Août","Septembre","Octobre","Novembre","Décembre"}[m-1];
}