namespace GenericMenu;

public class Menu
{
    /// <summary>
    /// Initialises ListMenu method with overrides
    /// </summary>
    /// <param name="listToShow">The list to use as menu.</param>
    /// <returns>The chosen object from the list.</returns>
    public static T ListMenu<T>(List<T> listToShow)
    {
        return ShowMenuAndCheckUserInput(listToShow, Config.ShowNumbers, Config.Brackets);
    }
    public static T ListMenu<T>(List<T> listToShow, bool showNumbers)
    {
        return ShowMenuAndCheckUserInput(listToShow, showNumbers, Config.Brackets);
    }
    public static T ListMenu<T>(List<T> listToShow, bool showNumbers, string brackets)
    {
        return ShowMenuAndCheckUserInput(listToShow, showNumbers, brackets);
    }

    /// <summary>
    /// Gets the list from the method ListMenu, with optional overrides for showing and formating of prefix-numbers in the list
    /// </summary>
    /// <param name="listToShow">The list to use as menu.</param>
    /// <param name="showNumbers">Bool to control wether or not prefix-numbers should be written out before the item</param>
    /// <param name="brackets">The format of the prefix numbers.</param>
    /// <returns>The chosen object from the list, or default(T) if no item were chosen</returns>
    public static T ShowMenuAndCheckUserInput<T>(List<T> listToShow, bool showNumbers, string brackets)
    {
        bool menuActive = true;
        int activeItem = 1;
        int activePage = 1;
        int totalItems = listToShow.Count;

        while (menuActive)
        {
            Console.Clear();
            int itemsPerPage = MenuRepository.GetItemsPerPage(totalItems);
            int totalPages = MenuRepository.GetTotalPages(itemsPerPage, totalItems);

            (int, int, int, int) pagesData = (totalPages, activePage, itemsPerPage, totalItems);

            MenuRepository.UpdateMenu(activeItem, pagesData, listToShow, showNumbers, brackets);
            UI.WriteMenuInstructions();
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    activeItem = activeItem == 1 ? listToShow.Count : activeItem - 1;
                    break;
                case ConsoleKey.DownArrow:
                    activeItem = activeItem == listToShow.Count ? 1 : activeItem + 1;
                    break;
                case ConsoleKey.LeftArrow:
                    activePage = activePage == 1 ? 1 : activePage - 1;
                    break;
                case ConsoleKey.RightArrow:
                    activePage = activePage == totalPages ? totalPages : activePage + 1;
                    break;
                case ConsoleKey.Enter:
                    return listToShow[activeItem - 1];
                case Config.ReturnKey:
                    menuActive = false;
                    break;
                default:
                    continue;
            }
            MenuRepository.UpdateMenu(activeItem, pagesData, listToShow, showNumbers, brackets);
        }
        return default;
    }

}