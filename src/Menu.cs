namespace Generisk_meny;

class Menu
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
    /// <returns>The chosen object from the list, or default(T) if no item were chosen</returns>
    public static T ShowMenuAndCheckUserInput<T>(List<T> listToShow, bool showNumbers, string brackets)
    {
        bool menuActive = true;
        int activeItem = 1;
        while (menuActive)
        {
            Console.Clear();
            MenuRepository.UpdateMenu(activeItem, listToShow, showNumbers, brackets);
            UI.MenuInstructions();
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (activeItem == 1)
                    {
                        activeItem = listToShow.Count;
                    }
                    else
                    {
                        activeItem--;
                    }
                    MenuRepository.UpdateMenu(activeItem, listToShow, showNumbers, brackets);
                    break;
                case ConsoleKey.DownArrow:
                    if (activeItem == listToShow.Count)
                    {
                        activeItem = 1;
                    }
                    else
                    {
                        activeItem++;
                    }
                    MenuRepository.UpdateMenu(activeItem, listToShow, showNumbers, brackets);
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