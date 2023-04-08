using VaultCore.CoreAPI;

namespace VaultCore.ImGuiWindowsAPI;

/// <summary>
/// Feature for interfacing with an ImGui Window Manager in a Vault GUI application
/// </summary>
public interface IImGuiWindowManager : IVaultCoreFeature
{
    /// <summary>
    /// Returns true if any window is set as the full screen window
    /// </summary>
    public bool IsAnyWindowFullScreen { get; }

    /// <summary>
    /// Returns the window that is currently full screen, or null if no window is full screen
    /// </summary>
    /// <returns>The window currently fullscreen, or null if none is</returns>
    public ImGuiWindow? GetFullscreenWindow();

    /// <summary>
    /// Registers a window in the manager
    /// </summary>
    /// <param name="window">Window to register to drawing</param>
    public void RegisterWindow(ImGuiWindow window);

    /// <summary>
    /// Unregisters a window in the manager
    /// </summary>
    /// <param name="window">Window to unregister for drawing</param>
    public void UnregisterWindow(ImGuiWindow window);

    /// <summary>
    /// Unregisters a window in the manager
    /// </summary>
    /// <param name="window">Window to set open state on</param>
    /// <param name="open">is the window open (been drawn)</param>
    public void SetWindowOpen(ImGuiWindow window, bool open);

    /// <summary>
    /// Sets this window as the full screen window
    /// </summary>
    /// <param name="window">Window to set fullscreen</param>
    public void SetWindowAsFullscreen(ImGuiWindow window);

    /// <summary>
    /// Clears any window that is full screen
    /// </summary>
    public void ClearFullscreenWindow();
}