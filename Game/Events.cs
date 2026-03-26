using System;

public static class Events
{
    //run all events for the current turn
    public static void ProcessAll() {
        ProcessFire();
        ProcessTheft();
        ProcessPests();
        ProcessRottenMeat();
    }

    //fire: 1% chance → lose 1 habitat
    private static void ProcessFire() {
        if (Rng.Chance(0.01))
            Console.WriteLine("FIRE! Lost a habitat.");
    }

    //theft: 1% chance → lose 1 animal
    private static void ProcessTheft() {
        if (Rng.Chance(0.01)) {
            var alive = Animals.AllAnimals.FindAll(a => a.Isalive);
            if (alive.Count > 0) {
                Rng.Pick(alive).Isalive = false;
                Console.WriteLine("THEFT! An animal was stolen!");
            }
        }
    }

    //pests: 20% chance → lose 10% of seeds
    private static void ProcessPests() {
        if (Rng.Chance(0.20)) {
            Food? seeds = Food.AllFoods.Find(f => f.Name == "seeds");
            if (seeds != null) {
                int lost = (int)(seeds.Quantity * 0.10); 
                seeds.Quantity -= lost;
                Console.WriteLine($"PESTS! Lost {lost}kg of seeds.");
            }
        }
    }

    //rotten meat: 10% chance → lose 20% of meat
    private static void ProcessRottenMeat() {
        if (Rng.Chance(0.10)) {
            Food? meat = Food.AllFoods.Find(f => f.Name == "meat");
            if (meat != null) {
                int lost = (int)(meat.Quantity * 0.20); 
                meat.Quantity -= lost;
                Console.WriteLine($" ROTTEN MEAT! Lost {lost}kg of meat.");
            }
        }
    }
}