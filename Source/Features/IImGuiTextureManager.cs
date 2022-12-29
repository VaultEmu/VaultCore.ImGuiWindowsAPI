using VaultCore.CoreAPI;
using VaultCore.Rendering;

namespace VaultCore.ImGuiWindowsAPI;

/// <summary>
/// Feature for converting textures for use with ImGui
/// </summary>
public interface IImGuiTextureManager : IVaultCoreFeature<IImGuiTextureManager.FeatureApi>
{
    public interface FeatureApi : IVaultCoreFeatureApi
    {
        /// <summary>
        /// Gets or Creates a ImGuiTextureRef from a Texture2D. These can be used in ImGui calls that need a user texture pointer
        /// </summary>
        /// <param name="texture">Texture to create ImGuiTextureRef for</param>
        /// <returns>ImGuiTextureRef that can be used to use the passed in texture in ImGui calls</returns>
        public ImGuiTextureRef GetOrCreateImGuiTextureRefForTexture(Texture2D texture);
    }
}