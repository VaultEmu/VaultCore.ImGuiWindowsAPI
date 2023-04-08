using ImGuiNET;

namespace VaultCore.ImGuiWindowsAPI;

//Base class to implement to create a Custom ImGui window for the Vault GUI application
public abstract class ImGuiWindow : IDisposable
{
    //Defines how the window should appear in the "Windows" menu
    public class WindowMenuItem
    {
        //Path in the menu. If the path is seperated by "/" then submenus will be created
        //e.g. "MyMenu/ThisWindow" Will create a Submenu MyMenu with ThisWindow as an item inside it
        public string MenuPath;
        
        //Order to add this to the "Windows" Menu, lower is higher up
        //If there is a difference of more then 100 between items, a 
        //separator will be added before the item
        public int Priority;

        public WindowMenuItem(string menuPath, int priority = 0)
        {
            MenuPath = menuPath;
            Priority = priority;
        }
    }
    
    // Order Of Execution for functions

    // WINDOW UPDATE STEP
    // foreach Window:
    // - OnUpdate()
    //
    // WINDOW DRAW STEP
    // foreach Window that has WindowIsOpen == true:
    // - OnBeforeDrawImGuiWindow()
    // - OnDrawImGuiWindowContent()
    // - OnAfterDrawImGuiWindow()
    
    //Name to show on the window
    public abstract string WindowTitle { get; }

    //Window ID
    //If Window title is not constant, override this to provide a consistent, unique ID for the window
    public virtual string WindowID => WindowTitle;

    //ImGui window flags for this window
    public virtual ImGuiWindowFlags WindowFlags => ImGuiWindowFlags.None;
    
    //If true, then the user cannot close this window
    public virtual bool WindowAlwaysOpen => false;
    
    //If there are not existing window open settings for this window, should this window be open by default?
    public virtual bool WindowOpenByDefault => true;
    
    //Data for adding this window to the "Windows" Menu. Can return null
    //to not add this window to the windows menu
    public virtual WindowMenuItem? WindowsMenuItemData => new WindowMenuItem(WindowTitle);

    //Call to run any updates on the windows in the update pass
    public virtual void OnUpdate() { }

    //Called to run any ImGui commands before beginning to draw the window
    public virtual void OnBeforeDrawImGuiWindow() { }

    //Called to draw a window's content
    public virtual void OnDrawImGuiWindowContent() { }

    //Called to run any ImGui commands after drawing the window
    public virtual void OnAfterDrawImGuiWindow() { }

    protected virtual void Dispose(bool disposing) { }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}