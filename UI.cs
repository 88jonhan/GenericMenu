namespace Generisk_meny;

class UI
{
    public static void MenuInstructions()
    {
        Console.WriteLine("\n↑↓ för att välja");
        Console.WriteLine("Enter för att bekräfta");
        Console.WriteLine($"{Config.ReturnKey} för att avbryta");
    }
}
