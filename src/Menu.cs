using System.Data;
using System.Runtime.Serialization;

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
        int cursorTop = Console.CursorTop;
        int activePage = 1;

        bool menuActive = true;
        int activeItem = 1;
        while (menuActive)
        {
            Console.Clear();
            (int, int) pagesAndRemainder = TotalPages(listToShow.Count, Console.WindowHeight);
            UpdateMenu(activeItem, listToShow, showNumbers, brackets, activePage, pagesAndRemainder);
            //UI.WriteMenuInstructions();

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
                    break;
                case ConsoleKey.RightArrow:
                    if (activePage != pagesAndRemainder.Item1)
                    {
                        activePage++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (activePage != 1)
                    {
                        activePage--;
                    }
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

    public static void UpdateMenu<T>(int activeItem, List<T> listToShow, bool showNumbers, string brackets, int activePage, (int, int) pagesAndRemainder)
    {
        int windowHeight = Console.WindowHeight;
        int windowWidth = Console.WindowWidth;

        int cursorLeft = Console.CursorLeft;
        int cursorTop = Console.CursorTop;
        int rowsPerPage = 4;
        int iteration = 1;
        int currentPage = 1;

        if (listToShow.Count > rowsPerPage)
        {
            while (currentPage <= rowsPerPage)
            {
                if (currentPage == 1)
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                }
                else
                {
                    Console.SetCursorPosition(cursorLeft, Console.CursorTop);
                }

                for (int j = 1; j < windowWidth; j++)
                {
                    Console.Write(" ");
                }

                if (currentPage == 1)
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                }
                else
                {
                    Console.SetCursorPosition(cursorLeft, Console.CursorTop);
                }

                if (MenuRepository.CheckIfActive(activeItem, iteration))
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    if (showNumbers)
                    {
                        Console.Write($"{brackets.Replace("T", $"{iteration}")} ");
                    }
                    Console.WriteLine(listToShow[i]);
                    Console.ResetColor();
                }
                else
                {
                    if (showNumbers)
                    {
                        Console.Write($"{brackets.Replace("T", $"{iteration}")} ");
                    }
                    Console.WriteLine(listToShow[i]);
                }
                iteration++;
            }
            Console.WriteLine($"\nSida {activePage}/{pagesAndRemainder.Item1}");
            Console.WriteLine(rowsPerPage + ", " + Console.WindowHeight);
        }
        else
        {
            foreach (var item in listToShow)
            {
                if (iteration == 1)
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                }
                else
                {
                    Console.SetCursorPosition(cursorLeft, Console.CursorTop);
                }

                for (int j = 1; j < windowWidth; j++)
                {
                    Console.Write(" ");
                }
                if (iteration == 1)
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                }
                else
                {
                    Console.SetCursorPosition(cursorLeft, Console.CursorTop);
                }
                if (MenuRepository.CheckIfActive(activeItem, iteration))
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


    public static (int, int) TotalPages(int totalItems, int windowHeight)
    {
        (int, int) pagesAndRemainder;
        int pages = 1;
        int rows = 4;
        int remainder = 0;
        if (totalItems > rows)
        {
            if (totalItems % rows == 0)
            {
                pages = totalItems / rows;
            }
            else
            {
                remainder = totalItems % rows;
                pages = (totalItems - remainder) / rows;
            }
        }
        pagesAndRemainder = (pages, remainder);
        return pagesAndRemainder;
    }
}