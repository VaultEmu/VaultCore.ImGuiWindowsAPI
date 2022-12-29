using VaultCore.CoreAPI;

namespace VaultCore.ImGuiWindowsAPI;

/// <summary>
/// Feature for interfacing with the ImGui Window Manager in VaultGUI
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
    public IImGuiWindow? GetFullscreenWindow();

    /// <summary>
    /// Registers a window in the manager
    /// </summary>
    /// <param name="window">Window to register to drawing</param>
    public void RegisterWindow(IImGuiWindow window);

    /// <summary>
    /// Unregisters a window in the manager
    /// </summary>
    /// <param name="window">Window to unregister for drawing</param>
    public void UnregisterWindow(IImGuiWindow window);

    /// <summary>
    /// Sets this window as the full screen window
    /// </summary>
    /// <param name="window">Window to set fullscreen</param>
    public void SetWindowAsFullscreen(IImGuiWindow window);

    /// <summary>
    /// Gets a window by its type. If window does not exist, null is returned
    /// </summary>
    /// <typeparam name="T">Type of the window to get (Type should inherit from IImGuiWindow)</typeparam>
    /// <returns>The window of the type requested, or null if no window of that type is registered</returns>
    public T? GetWindow<T>() where T : IImGuiWindow;

    /// <summary>
    /// Clears any window that is full screen
    /// </summary>
    public void ClearFullscreenWindow();
}