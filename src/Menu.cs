namespace GenericMenu;

public class Menu
{

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

    public static T ShowMenuAndCheckUserInput<T>(List<T> listToShow, bool showNumbers, string brackets)
    {
        bool menuActive = true;
        int activeItem = 1;
        int activePage = 1;
        int totalItems = listToShow.Count;

        while (menuActive)
        {
            Console.Clear();
            int itemsPerPage = MenuRepository.GetItemsPerPage();
            int totalPages = MenuRepository.GetTotalPages(itemsPerPage, totalItems);

            (int, int, int, int) pagesData = (totalPages, activePage, itemsPerPage, totalItems);

            MenuRepository.UpdateMenu(activeItem, pagesData, listToShow, showNumbers, brackets);
            UI.WriteMenuInstructions(itemsPerPage, totalItems);
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
        }
        return default;
    }

}