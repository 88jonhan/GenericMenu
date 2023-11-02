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

}