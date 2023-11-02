namespace GenericMenu;

class MenuRepository
{

    public static void CheckIfActive<T>(int iteration, int active, bool showNumbers, string brackets, T item)
    {
        if (iteration == active)
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
    }

    public static void UpdateMenu<T>(int activeItem, (int totalPages, int activePage, int itemsPerPage, int totalItems) pagesData, List<T> listToShow, bool showNumbers, string brackets)
    {
        int totalPages = pagesData.totalPages;
        int activePage = pagesData.activePage;
        int itemsPerPage = pagesData.itemsPerPage;
        int totalItems = pagesData.totalItems;

        int iteration = 1;

        if (totalPages == 1)
        {
            foreach (T item in listToShow)
            {
                CheckIfActive(activeItem, iteration, showNumbers, brackets, item);
                iteration++;
            }
        }
        else
        {
            int checkIfLastItem = 1;
            int currentItem = 0;
            int checkIfLastItemOnPage = 0;
            bool fewerOnLastPage = false;

            while (checkIfLastItem < totalItems)
            {
                int remainder = totalItems % itemsPerPage;
                if (remainder == 0)
                {
                    fewerOnLastPage = true;
                }
                while (checkIfLastItemOnPage < itemsPerPage)
                {
                    if (activePage == 1)
                    {
                        CheckIfActive(activeItem, iteration, showNumbers, brackets, listToShow[currentItem]);
                        currentItem++;
                    }
                    else if (activePage != totalPages)
                    {
                        CheckIfActive(activeItem * (activePage - 1), iteration, showNumbers, brackets, listToShow[itemsPerPage * (activePage - 1) + currentItem]);
                        currentItem++;
                    }
                    else if (activePage == totalPages)
                    {
                        if (remainder != 0)
                        {
                            currentItem = totalItems - remainder;
                            CheckIfActive(activeItem - remainder, iteration, showNumbers, brackets, listToShow[currentItem]);
                            remainder--;
                        }
                        else if (fewerOnLastPage)
                        {
                            CheckIfActive(activeItem + itemsPerPage, iteration, showNumbers, brackets, listToShow[itemsPerPage + currentItem]);
                            currentItem++;
                        }
                    }
                    checkIfLastItemOnPage++;
                    iteration++;
                }
                checkIfLastItem++;
            }
        }
        Console.WriteLine("Sida " + activePage + " av " + totalPages);
    }

    public static int GetItemsPerPage()
    {
        if (Console.BufferHeight <= 10)
        {
            return 1;
        }
        else
        {
            return Console.BufferHeight - 10;
        }
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
                return ((totalItems - remainder) / itemsPerPage) + 1;
            }
        }
    }
}