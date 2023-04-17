using VaultCore.CoreAPI;

namespace VaultCore.ImGuiWindowsAPI;

/// <summary>
/// Feature to allow registering menu items in the ImGui frontend
/// </summary>
public interface IImGuiMenuManager : IVaultCoreFeature
{
    /// <summary>
    /// Registers a menu item to be added to the main ImGui frontend menu
    /// </summary>
    /// <param name="menuItem">MenuItem to register</param>
    public void RegisterMenuItem(ImGuiMenuItem menuItem);
    
    /// <summary>
    /// Unregisters a menu item that was added
    /// </summary>
    /// <param name="menuItem">MenuItem to unregister</param>
    public void UnregisterMenuItem(ImGuiMenuItem menuItem);
}