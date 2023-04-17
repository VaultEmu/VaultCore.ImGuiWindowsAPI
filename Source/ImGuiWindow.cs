using ImGuiNET;

namespace VaultCore.ImGuiWindowsAPI;

//Base class to implement to create a Custom ImGui window for the Vault GUI application
public abstract class ImGuiWindow : IDisposable
{
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