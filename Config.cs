namespace Generisk_meny;

public class Config
{
    //False om nummer-prefix ej ska synas som standard
    //True om nummer-precis ska synas som standard
    public static bool ShowNumbers = false;


    //Standardformatering för nummmer-prefix
    //T = siffran som syns innan alternativet
    //Ex. [T] ger [1], (T) ger (1)
    public static string Brackets { get; set; } = "T. ";


    //Vilken knapp som ska tryckas på för att "avbryta"
    public const ConsoleKey ReturnKey = ConsoleKey.R;
}