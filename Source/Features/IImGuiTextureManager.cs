using VaultCore.CoreAPI;
using VaultCore.Rendering;

namespace VaultGUI.ImGuiWindowsAPI;

//Feature for converting textures for use with ImGui
public interface IImGuiTextureManager : IFeature
{
    //Gets or Creates a ImGuiTextureRef from a Texture2D. These can be used in ImGui calls that need a user texture pointer
    public ImGuiTextureRef GetOrCreateImGuiTextureRefForTexture(Texture2D texture);
}