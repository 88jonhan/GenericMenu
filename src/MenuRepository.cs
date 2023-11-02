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
    /// 
    //pagesData = (totalPages, activePage, itemsPerPage, totalItems);
    public static void UpdateMenu<T>(int activeItem, (int, int, int, int) pagesData, List<T> listToShow, bool showNumbers, string brackets)
    {
        int totalPages = pagesData.Item1;
        int activePage = pagesData.Item2;
        int itemsPerPage = pagesData.Item3;
        int totalItems = pagesData.Item4;

        int iteration = 1;

        if (totalPages == 1)
        {
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
        else
        {
            int checkIfLastItem = 0;
            int currentItem = 0;
            int checkIfLastItemOnPage = 0;


            while (checkIfLastItem < totalItems)
            {
                while (checkIfLastItemOnPage < itemsPerPage)
                {
                    Console.WriteLine(listToShow[currentItem]);
                    checkIfLastItemOnPage++;
                    currentItem++;
                }
                checkIfLastItem++;
            }
        }
        Console.WriteLine(activePage + "/" + totalPages);
    }

    public static int GetItemsPerPage(int totalItems)
    {
        int itemsPerPage;
        if (Console.WindowHeight <= 10)
        {
            itemsPerPage = 1;
        }
        else
        {
            itemsPerPage = Console.WindowHeight - 10;
        }
        return itemsPerPage;
    }

    public static int GetTotalPages(int itemsPerPage, int totalItems)
    {
        if (totalItems < itemsPerPage)
        {
            return 1;
        }
        else
        {
            if (totalItems % itemsPerPage == 0)
            {
                return totalItems / itemsPerPage;
            }
            else
            {
                int remainder = totalItems % itemsPerPage;
                return (totalItems - remainder) / itemsPerPage;
            }
        }
    }
}