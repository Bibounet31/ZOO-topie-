using System.Threading;

public class Saves
{
    private static string GetSavePath(int slot)
    {
        //each slot will be a save
        return $"Saves/save{slot}.csv";
    }


    //Save -> Write current game values into csv file
    public static void Save(int slot)
    {
        string path = GetSavePath(slot);
        string csv = "Difficulty,Name\n";
        csv += $"{Settings.Difficulty},{Settings.Name}";

        File.WriteAllText(path, csv);
        UI.Success($"Game saved to slot {slot}");
    }


    //LOAD 
    public static void Load(int slot)
    {
        string path = GetSavePath(slot);

        if (!File.Exists(path))
        {
            UI.Error($"Save {slot} is empty");
            return;
        }

        string[] lines = File.ReadAllLines(path);
        string[] values = lines[1].Split(',');

        Settings.Difficulty = values[0];
        Settings.Name = values[1];

        UI.Success($"Slot {slot} loaded!");
        Thread.Sleep(710);
        Menu.MenuZoo();
    }

    // check if a slot already has a save in it
    public static bool SlotExists(int slot)
    {
        return File.Exists(GetSavePath(slot));
    }
}