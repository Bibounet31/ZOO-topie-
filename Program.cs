using System;

class Program
{
    static void Main()
    {
		//random debug from when i was lost, might be usefull sometimes
        Console.WriteLine("program.cs called!");


		// create new Animals... (calling Public Animals in Animals.cs right >:3)	
		Animals tiger = new Animals("Tiger",120,"male",false,false, 200);
		Animals chicken = new  Animals("Chicken",10,"female",false,false,200);
		Animals eagle = new Animals("Eagle",15,"female",false,false,200);

		// uses the objects we created: tiger,chicken..... and calling ShowInfos on it
		tiger.ShowInfos();
		chicken.ShowInfos();
		eagle.ShowInfos();

    }
}