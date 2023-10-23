namespace Generisk_meny;

class Program
{
    static void Main(string[] args)
    {
        List<string> strings = new List<string>() { "Första", "Andra", "Tredje", "Fjärde" };
        List<int> ints = new List<int>() { 1, 2, 3, 4 };

        List<GenericItem1> items1 = new List<GenericItem1>()
        {
            new GenericItem1() { Name = "Namn 1", Id = 1 },
            new GenericItem1() { Name = "Namn 2", Id = 2 },
            new GenericItem1() { Name = "Namn 3", Id = 3 },
            new GenericItem1() { Name = "Namn 4", Id = 4 }
        };

        List<GenericItem2> items2 = new List<GenericItem2>()
        {
            new GenericItem2() { Title = "Title 1", Id = 1 },
            new GenericItem2() { Title = "Title 2", Id = 2 },
            new GenericItem2() { Title = "Title 3", Id = 3 },
            new GenericItem2() { Title = "Title 4", Id = 4 }
        };
        Console.CursorVisible = false;
        var item = Menu.ListMenu(items2, true, "T ->");

        if (item == default)
        {
            Console.Clear();
            Console.WriteLine("Returnerade null");

        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Returnerat objekt: {item}");
        }
    }
}
