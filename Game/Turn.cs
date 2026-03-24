using System;
using System.Collections.Generic;

public static class Turn
{
    private static int _currentMonth = 1; // 1 = january, 12 = december
    private static int _currentYear = 1;

    private static int _totalTurns = 0;

    //days per month
    private static int[] _daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    public static int GetDaysInCurrentMonth() {
        return _daysInMonth[_currentMonth - 1];
    }

    //high season = may to september
    public static bool IsHighSeason() {
        return _currentMonth >= 5 && _currentMonth <= 9;
    }

    //main turn loop
    public static void Next() {
        Console.WriteLine($"\n===== Turn : {GetMonthName(_currentMonth)} year {_currentYear} ({GetDaysInCurrentMonth()} days) =====");

        ProcessFeeding();
        ProcessReproduction();
        ProcessAging();
        ProcessIllness();
        ProcessOverpopulation();
        ProcessVisitors();
        ProcessSubventions();
        Events.ProcessAll();
        AdvanceMonth();
    }

    //feeding
    private static void ProcessFeeding() {
        int days = GetDaysInCurrentMonth();
        double totalMeat = 0;
        double totalSeeds = 0;

        foreach (var animal in Animals.AllAnimals) {
            if (!animal.Isalive) continue;

            double dailyFood = GetDailyFood(animal);

            //pregnant females eat x2
            if (animal.Ispregnant) dailyFood *= 2;

            double needed = dailyFood * days;

            if (animal.Name.ToLower() == "tiger" || animal.Name.ToLower() == "eagle")
                totalMeat += needed;
            else
                totalSeeds += needed;
        }

        double meatCost  = totalMeat  * 5.0;
        double seedsCost = totalSeeds * 2.5;
        double totalCost = meatCost + seedsCost;

        Console.WriteLine($"Food needed this month: {totalMeat}kg of meat, {totalSeeds}kg of seeds");
        Console.WriteLine($"Feeding cost: {totalCost}€ (meat: {meatCost}€, seeds: {seedsCost}€)");
        Bank.bankaccount.RemoveMoney(totalCost);

        // TODO: check if enough food stock, if not → animal is hungry
        // when hungry -> not yet implemented
    }

    private static double GetDailyFood(Animals animal) {
        return animal.Name.ToLower() switch {
            "tiger" => animal.Gender == "Male" ? 12 : 10,
            "eagle" => animal.Gender == "Male" ? 0.25 : 0.3,
            "hen"   => 0.15,
            "rooster" => 0.18,
            _       => 0
        };
    }

    //reproduction
    private static void ProcessReproduction() {
        foreach (var female in Animals.AllAnimals) {
            if (!female.Isalive) continue;
            if (female.Gender != "Female") continue;
            if (female.Ispregnant) continue;
            if (female.Illness != "false") continue; // no repro if sick
            // when hungry → not yet implemented

            if (!HasSpace(female)) continue;
            if (!HasMate(female)) continue;

            double ageInYears = female.Age / 12.0;
            (double maturity, double endRepro) = GetReproAges(female);
            if (ageInYears < maturity || ageInYears > endRepro) continue;

            //eagle only reproduces in march
            if (female.Name.ToLower() == "eagle" && _currentMonth != 3) continue;

            female.Ispregnant = true;
            Console.WriteLine($"{female.Name} (female) is now pregnant!");
        }

        //gestation and handle births
        foreach (var female in Animals.AllAnimals) {
            if (!female.Isalive || !female.Ispregnant) continue;

            female.GestationMonths++;

            if (female.GestationMonths >= GetGestationMonths(female))
                GiveBirth(female);
        }
    }

    private static void GiveBirth(Animals mother) {
        mother.Ispregnant = false;
        mother.GestationMonths = 0;

        int litterSize = GetLitterSize(mother);
        Console.WriteLine($"{mother.Name} gave birth to {litterSize} offspring!");

        for (int i = 0; i < litterSize; i++) {
            if (Rng.Chance(GetInfantMortality(mother))) {
                Console.WriteLine($"  → A baby {mother.Name} was stillborn (infant mortality).");
                continue;
            }
            RandomGender rg = new RandomGender();
            new Animals(mother.Name, 0, rg.Gender, false, true, 0, "false");
            Console.WriteLine($"  → New {mother.Name} ({rg.Gender}) was born!");
        }
    }

    private static bool HasSpace(Animals female) {
        int count = Animals.AllAnimals.FindAll(a => a.Name == female.Name && a.Isalive).Count;
        return count < GetHabitatCapacity(female.Name);
    }

    private static bool HasMate(Animals female) {
        return Animals.AllAnimals.Exists(a =>
            a.Isalive &&
            a.Gender == "Male" &&
            a.Name == female.Name &&
            a.Illness == "false"
        );
    }

    private static (double maturity, double endRepro) GetReproAges(Animals a) {
        return a.Name.ToLower() switch {
            "tiger"   => (4, 14),
            "eagle"   => (4, 14),
            "hen"     => (0.5, 8),
            "rooster" => (0.5, 8),
            _         => (999, 0)
        };
    }

    private static int GetGestationMonths(Animals a) {
        return a.Name.ToLower() switch {
            "tiger" => 3,
            "eagle" => 2, // ~45 days ≈ 2 months
            "hen"   => 1, // ~6 weeks ≈ 1 month
            _       => 1
        };
    }

    private static int GetLitterSize(Animals a) {
        return a.Name.ToLower() switch {
            "tiger" => 3,
            "eagle" => 2,
            "hen"   => Rng.Range(15, 25), // ~200/year ÷ ~10 clutches
            _       => 1
        };
    }

    private static double GetInfantMortality(Animals a) {
        return a.Name.ToLower() switch {
            "tiger" => 0.33,
            "eagle" => 0.50,
            "hen"   => 0.50,
            _       => 0
        };
    }

    //aging and death
    private static void ProcessAging() {
        foreach (var animal in Animals.AllAnimals) {
            if (!animal.Isalive) continue;

            animal.Age++; // 1 month per turn

            double ageInYears = animal.Age / 12.0;
            if (ageInYears >= GetLifespan(animal)) {
                animal.Isalive = false;
                Console.WriteLine($"{animal.Name} died of old age at {ageInYears:F1} years.");
            }
        }
    }

    private static double GetLifespan(Animals a) {
        return a.Name.ToLower() switch {
            "tiger"   => 25,
            "eagle"   => 25,
            "hen"     => 15,
            "rooster" => 15,
            _         => 10
        };
    }

    //illness
    private static void ProcessIllness() {
        foreach (var animal in Animals.AllAnimals) {
            if (!animal.Isalive) continue;

            //advance illness duration
            if (animal.Illness != "false") {
                animal.IllnessDaysLeft--;
                if (animal.IllnessDaysLeft <= 0) {
                    // 10% chance of dying from illness
                    if (Rng.Chance(0.10)) {
                        animal.Isalive = false;
                        Console.WriteLine($"{animal.Name} died from illness.");
                    } else {
                        animal.Illness = "false";
                        Console.WriteLine($"{animal.Name} has recovered!");
                    }
                }
                continue;
            }

            //check if gets sick this month
            if (Rng.Chance(GetMonthlyIllnessChance(animal))) {
                int baseDays = GetIllnessDuration(animal);
                animal.IllnessDaysLeft = (int)(baseDays * Rng.Variation());
                animal.Illness = "sick";
                Console.WriteLine($"{animal.Name} got sick for {animal.IllnessDaysLeft} days!");
            }
        }
    }

    private static double GetMonthlyIllnessChance(Animals a) {
        //annual % converted to monthly
        return a.Name.ToLower() switch {
            "tiger"              => 0.30 / 12,
            "eagle"              => 0.10 / 12,
            "hen" or "rooster"   => 0.05 / 12,
            _                    => 0
        };
    }

    private static int GetIllnessDuration(Animals a) {
        return a.Name.ToLower() switch {
            "tiger"            => 15,
            "eagle"            => 30,
            "hen" or "rooster" => 5,
            _                  => 7
        };
    }

    //overpopulation
    private static void ProcessOverpopulation() {
        string[] species = { "tiger", "eagle", "hen" };

        foreach (var name in species) {
            var group    = Animals.AllAnimals.FindAll(a => a.Isalive && a.Name.ToLower() == name);
            int capacity = GetHabitatCapacity(name);

            if (group.Count > capacity) {
                int deaths = GetOverpopulationDeaths(name);
                Console.WriteLine($"Overpopulation of {name}! ({group.Count}/{capacity})");

                for (int i = 0; i < deaths; i++) {
                    if (group.Count == 0) break;
                    if (Rng.Chance(0.5)) {
                        Animals victim = Rng.Pick(group);
                        victim.Isalive = false;
                        group.Remove(victim);
                        Console.WriteLine($"  → A {name} died from overpopulation.");
                    }
                }
            }
        }
    }

    private static int GetHabitatCapacity(string name) {
        return name.ToLower() switch {
            "tiger"              => 2,
            "eagle"              => 4,
            "hen" or "rooster"   => 10,
            _                    => 5
        };
    }

    private static int GetOverpopulationDeaths(string name) {
        return name.ToLower() switch {
            "tiger"            => 1,
            "eagle"            => 1,
            "hen" or "rooster" => 4,
            _                  => 1
        };
    }

    //visitors and revenue
    private static void ProcessVisitors() {
        bool highSeason = IsHighSeason();
        double totalVisitors = 0;

        foreach (var animal in Animals.AllAnimals) {
            if (!animal.Isalive) continue;
            totalVisitors += GetVisitorsPerAnimal(animal, highSeason) * Rng.Variation();
        }

        //2 adults + 2 children per group
        int groups     = (int)(totalVisitors / 4);
        double revenue = groups * (2 * 17.0 + 2 * 13.0); // adults 17€, kids 13€

        Console.WriteLine($"Visitors this month: ~{(int)totalVisitors} ({(highSeason ? "high" : "low")} season) → {revenue}€");
        Bank.bankaccount.AddMoney(revenue);
    }

    private static double GetVisitorsPerAnimal(Animals a, bool highSeason) {
        return a.Name.ToLower() switch {
            "tiger"              => highSeason ? 30 : 5,
            "eagle"              => highSeason ? 15 : 7,
            "hen" or "rooster"   => highSeason ? 2 : 0.5,
            _                    => 0
        };
    }

    //subventions paid every january
    private static void ProcessSubventions() {
        if (_currentMonth != 1) return;
        if (_totalTurns == 0) return;
        double total = 0;
        foreach (var animal in Animals.AllAnimals) {
            if (!animal.Isalive) continue;
            total += GetAnnualSubvention(animal);
        }

        if (total > 0) {
            Console.WriteLine($"Annual subsidy received: {total}€");
            Bank.bankaccount.AddMoney(total);
        }
    }

    private static double GetAnnualSubvention(Animals a) {
        return a.Name.ToLower() switch {
            "tiger" => 43800,
            "eagle" => 2190,
            _       => 0
        };
    }

    //exceptional events
    private static void ProcessExceptionalEvents() {
        //fire: 1% → lose 1 habitat
        if (Rng.Chance(0.01))
            Console.WriteLine("FIRE! Lost a habitat.");

        //theft: 1% → lose 1 animal
        if (Rng.Chance(0.01)) {
            var alive = Animals.AllAnimals.FindAll(a => a.Isalive);
            if (alive.Count > 0) {
                Rng.Pick(alive).Isalive = false;
                Console.WriteLine($"THEFT! An animal was stolen!");
            }
        }

        //pests: 20% → lose 10% of seeds
        if (Rng.Chance(0.20))
            Console.WriteLine("PESTS! Lost 10% of seeds.");

        //rotten meat: 10% → lose 20% of meat
        if (Rng.Chance(0.10))
            Console.WriteLine("ROTTEN MEAT! Lost 20% of meat.");
    }

    //advance to next month
    private static void AdvanceMonth()
    {
        _totalTurns++;
        _currentMonth++;
        if (_currentMonth > 12) {
            _currentMonth = 1;
            _currentYear++;
        }
    }

    private static string GetMonthName(int month) {
        return month switch {
            1  => "January",   2  => "February",  3  => "March",
            4  => "April",     5  => "May",        6  => "June",
            7  => "July",      8  => "August",     9  => "September",
            10 => "October",   11 => "November",   12 => "December",
            _  => "?"
        };
    }
}