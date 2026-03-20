public class Saves
{
    private static string GetSavePath(int slot)
    {
        //each slot will be a save
        return $"save{slot}.csv";
    }


    //Save -> Write current game values into csv file
    public static void Save(int slot)
    {
        string path = GetSavePath(slot);
        string csv = "Difficulty,Name\n";
        csv += $"{Settings.Difficulty},{Settings.Name}";

        File.WriteAllText(path, csv);
        Console.WriteLine($"Game saved to slot {slot}");
    }


    //LOAD 
    public static void Load(int slot)
    {
        string path = GetSavePath(slot);

        if (!File.Exists(path))
        {
            Console.WriteLine($"Save {slot} is empty");
            return;
        }

        string[] lines = File.ReadAllLines(path);
        string[] values = lines[1].Split(',');

        Settings.Difficulty = values[0];
        Settings.Name = values[1];

        Console.WriteLine($"Slot {slot} loaded!");
    }

    // check if a slot already has a save in it
    public static bool SlotExists(int slot)
    {
        return File.Exists(GetSavePath(slot));
    }
}