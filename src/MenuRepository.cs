namespace GenericMenu;

class MenuRepository
{
    /// <summary>
    /// Checks of the current iteration of the loop represents the active item
    /// </summary>
    /// <param name="iteration">Current iteration of the loop</param>
    /// <param name="active">The item in the list that should be active</param>
    /// <returns>Bool if the current iteration represents the current item</returns>
    public static bool CheckIfActive(int iteration, int active)
    {
        bool isActive = false;
        if (iteration == active)
        {
            isActive = true;
        }
        return isActive;
    }

    /// <summary>
    /// Updates the menu based on user inputs
    /// </summary>
    /// <param name="activeItem">Integer which represents the current active item</param>
    /// <param name="listToShow">The list to use as menu.</param>
    /// <param name="showNumbers">Bool to control wether or not prefix-numbers should be written out before the item</param>
    /// <param name="brackets">The format of the prefix numbers.</param>
    /// <returns>The chosen object from the list.</returns>
    public static void UpdateMenu<T>(int activeItem, List<T> listToShow, bool showNumbers, string brackets)
    {
        int iteration = 1;
        foreach (T item in listToShow)
        {
            if (CheckIfActive(activeItem, iteration))
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                if (showNumbers)
                {
                    Console.Write($"{brackets.Replace("T", $"{iteration}")} ");
                }
                Console.WriteLine(item);
                Console.ResetColor();
            }
            else
            {
                if (showNumbers)
                {
                    Console.Write($"{brackets.Replace("T", $"{iteration}")} ");
                }
                Console.WriteLine(item);
            }
            iteration++;
        }
    }
}