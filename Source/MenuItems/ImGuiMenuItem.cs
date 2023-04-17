namespace VaultCore.ImGuiWindowsAPI;

//Defines a menu item that should appear in the main menus
public class ImGuiMenuItem
{
    /// <summary>
    /// Path in the menu. If the path is seperated by "/" then submenus will be created
    /// e.g. "Test/MyMenu/ThisWindow" Will create a Menu "Test" with a submenu "MyMenu" with "ThisWindow" as an item inside it
    /// </summary>
    public string MenuPath;
        
    /// <summary>
    /// The shortcut to open this window, will be displayed next to the menu item
    /// If null then no shortcut is set
    /// </summary>
    public ImGuiShortcut? Shortcut;
        
    /// <summary>
    /// Order to add this to its Menu, lower is further to the right in root menus and higher up in submenus
    /// If there is a difference of more then 100 between items, a separator will be added before the item
    /// </summary>
    public int Priority;
    
    /// <summary>
    /// What to do when this menu item is selected
    /// </summary>
    public Action MenuAction;
    
    /// <summary>
    /// Returns if the menu item should be shown as "Selected" in the menu with a tick
    /// If null, then will not be selected
    /// </summary>
    public Func<bool>? IsItemChecked;

    /// <summary>
    /// Create a new ImGuiMenuItem
    /// </summary>
    /// <param name="menuPath">Path for the menu (See MenuPath)</param>
    /// <param name="menuAction">Action to run when the menu item is selected (See MenuAction)</param>
    /// <param name="shortcut">Shortcut to press to activate menu item (See Shortcut)</param>
    /// <param name="isItemChecked">Function to check if item is selected (see IsItemChecked)</param>
    /// <param name="priority">Priority of the menu item (See Priority)</param>
    public ImGuiMenuItem(
        string menuPath, 
        Action menuAction, 
        ImGuiShortcut? shortcut = null,
        Func<bool>? isItemChecked = null,
        int priority = 0)
    {
        MenuPath = menuPath;
        Shortcut = shortcut;
        Priority = priority;
        MenuAction = menuAction;
        isItemChecked = isItemChecked;
    }
}