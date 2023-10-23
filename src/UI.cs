namespace GenericMenu;

class UI
{
    static UI()
    {
        Console.CursorVisible = false;
    }
    public static void WriteMenuInstructions()
    {
        Console.WriteLine("\n↑↓ för att välja");
        Console.WriteLine("Enter för att bekräfta");
        Console.WriteLine($"{Config.ReturnKey} för att avbryta");
    }
}
