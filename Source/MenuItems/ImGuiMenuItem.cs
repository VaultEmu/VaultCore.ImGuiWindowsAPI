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
    /// Return null for no shortcut
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

    public ImGuiMenuItem(string menuPath, Action menuAction, ImGuiShortcut? shortcut = null, int priority = 0)
    {
        MenuPath = menuPath;
        Shortcut = shortcut;
        Priority = priority;
        MenuAction = menuAction;
    }
}