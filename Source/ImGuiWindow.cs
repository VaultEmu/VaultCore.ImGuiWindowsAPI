using ImGuiNET;

namespace VaultCore.ImGuiWindowsAPI;
/// <summary>
/// Base class to implement to create a Custom ImGui window for the Vault GUI application
/// </summary>
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
    
    /// <summary>
    /// Name to show on the window
    /// </summary>
    public abstract string WindowTitle { get; }

    /// <summary>
    /// Window ID
    /// If Window title is not constant, override this to provide a consistent, unique ID for the window
    /// </summary>
    public virtual string WindowID => WindowTitle;

    /// <summary>
    /// ImGui window flags for this window
    /// </summary>
    public virtual ImGuiWindowFlags WindowFlags => ImGuiWindowFlags.None;
    
    /// <summary>
    /// If true, then this window is open (is drawn by ImGui)
    /// </summary>
    public virtual bool IsWindowOpen => true;
    
    /// <summary>
    /// If true, then the close button will be showed in the window title bar
    /// </summary>
    public virtual bool ShowCloseButton => true;

    /// <summary>
    /// Call to run any updates on the windows in the update pass
    /// </summary>
    public virtual void OnUpdate() { }

    /// <summary>
    /// Called to run any ImGui commands before beginning to draw the window
    /// </summary>
    public virtual void OnBeforeDrawImGuiWindow() { }

    /// <summary>
    /// Called to draw a window's content
    /// </summary>
    public virtual void OnDrawImGuiWindowContent() { }

    /// <summary>
    /// Called to run any ImGui commands after drawing the window
    /// </summary>
    public virtual void OnAfterDrawImGuiWindow() { }
    
    protected virtual void Dispose(bool disposing) { }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}