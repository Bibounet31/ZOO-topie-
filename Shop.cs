public class Shop
{
    public string Name { get; set; }
    public Dictionary<string, double> Items { get; set; }
    public double Balance { get; set; }

    public Shop(string name)
    {
        this.Name = name;
        Items = new Dictionary<string, double>();
        Balance = Bank.ShowMoney();
        Console.WriteLine($"Shop {Name} created");
    }

    public void AddItem(string item, double price)
    {
        Items.Add(item, price);
        Console.WriteLine($"{item} added for ${price}");
    }


    public void ShowInventory()
    {
        Console.WriteLine($"\n-- {Name} Inventory --");
        if (Items.Count == 0)
        {
            Console.WriteLine("No items in stock.");
        }
        else
        {
            foreach (var item in Items)
            {
                Console.WriteLine($"- {item.Key} : ${item.Value}");
            }
        }
    }

    public void Sell(string item, double price)
    {
        if (Items.ContainsKey(item))
        {
            Items.Remove(item);
            Balance += price;
            Console.WriteLine($"Sold '{item}' for ${price}. Balance: ${Balance}");
        }
        else
        {
            Console.WriteLine($"'{item}' is not available.");
        }
    }
}