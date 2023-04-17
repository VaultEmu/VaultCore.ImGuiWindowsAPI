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
    
    /// <summary>
    /// Sets the priority of a top level menu item. High the priority the further to the right it will be
    /// Items not explicitly set will be at Priority 0
    /// </summary>
    /// <param name="itemName">Name of the top level menu item (case insensitive)</param>
    /// <param name="Priority">priority to add the item</param>
    public void SetTopLevelMenuPriority(string itemName, int Priority);
}