using System;
using System.Collections.Generic;

public class Shop
{
    public string Name { get; set; }
    public Dictionary<string, double> Items { get; set; }

    public Shop(string name)
    {
        this.Name = name;
        Items = new Dictionary<string, double>();
    }

    public void AddItem(string item, double price)
    {
        if (!Items.ContainsKey(item)) Items.Add(item, price);
    }

    public void ShowInventory()
    {
        int i = 1;
        foreach (var item in Items)
        {
            UI.WriteLine($"  {UI.Tan}{i}.{UI.Reset} {item.Key.PadRight(20)} : {UI.Yellow}{item.Value}€{UI.Reset}");
            i++;
        }
        UI.WriteLine($"  {UI.Gray}0. Retour{UI.Reset}");
    }

    public void BuyItem(int choice)
    {
        if (choice <= 0 || choice > Items.Count) return;
        
        int current = 1;
        foreach (var item in Items)
        {
            if (current == choice)
            {
                if (Bank.ShowMoney() >= item.Value)
                {
                    Bank.bankaccount.RemoveMoney(item.Value);
                    
                    string itemName = item.Key.ToLower();

                    if (itemName.Contains("habitat")) {
                        UI.Success($"Extension achetée : {item.Key} !");
						// action after buying an extention.. (todo)
                    }
                    else if (itemName.Contains("viande") || itemName.Contains("graines")) {
                        UI.Success($"Provisions achetées : {item.Key}");
                    }
                    else {
                        new Animals(item.Key, 24, new RandomGender().Gender, false, true, item.Value, "false");
                        UI.Success($"Nouvel arrivant : Un {item.Key} a rejoint le zoo !");
                    }
                }
                else
                {
                    UI.Error("Fonds insuffisants.");
                }
                break;
            }
            current++;
        }
    }
}