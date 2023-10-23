# README 

# Menu.ListMenu(List<T>)
Funktionen har två overrides:

#   Menu.ListMenu(List<T>) //Visa listan utan numrering
    Item 1
    Item 2
    Item 3
    Item 4

#   Menu.ListMenu(List<T>, bool) // Visa listan med standard-numrering

    1. Item 1
    2. Item 2
    3. Item 3
    4. Item 4

#   Menu.ListMenu(List<T>, bool, string) //Visa listan med formaterad numrering. 
#   string = [T]
    [1] Item 1
    [2] Item 2
    [3] Item 3
    [4] Item 4
#   string = T ->
    1 -> Item 1
    2 -> Item 2
    3 -> Item 3
    4 -> Item 4

# För generiska objekt som inte är string eller int ska kunna visas korrekt behöver objekten ha en override ToString()
# Knapptryck Q returnerar ett objekt som är "default", vilket man behöver kontrollera 

Exempel:

//Skapa lista med objekt
    List<GenericItem1> items1 = new List<GenericItem1>()
    {
        new GenericItem1() { Name = "Name 1" },
        new GenericItem1() { Name = "Name 2" },
        new GenericItem1() { Name = "Name 3" },
        new GenericItem1() { Name = "Name 4" }
    };

//Skapa variabel item som kommer att vara ett objekt ur listan, eller "default" (vilket innebär att användaren avbrutit åtgärden)
    var item = ListMenu(items1)


//Klass för vårt objekt med ToString() override
    public class GenericItem1
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }# README 
