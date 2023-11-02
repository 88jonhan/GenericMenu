namespace GenericMenu;

class UI
{
    static UI()
    {
        Console.CursorVisible = false;
    }
    public static void WriteMenuInstructions(int itemsPerPage, int totalItems)
    {
        Console.WriteLine("\n↑↓ för att välja");
        Console.WriteLine("Enter för att bekräfta");
        Console.WriteLine($"{Config.ReturnKey} för att avbryta");
        Console.WriteLine($"Fönstret är {Console.BufferHeight} hög och visar {itemsPerPage} rader.");
        Console.WriteLine($"Totalt ska det visas {totalItems} items.");
    }
}
