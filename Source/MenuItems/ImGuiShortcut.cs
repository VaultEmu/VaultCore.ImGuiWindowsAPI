using System.Text;
using ImGuiNET;

namespace VaultCore.ImGuiWindowsAPI;

/// <summary>
/// Represents a Keyboard shortcut that ImGui can check is triggered or display in a menu
/// </summary>
public class ImGuiShortcut
{
    private static string[] GKeyNames = new []
    {
        "Tab", "LeftArrow", "RightArrow", "UpArrow", "DownArrow", "PageUp", "PageDown",
        "Home", "End", "Insert", "Delete", "Backspace", "Space", "Enter", "Escape",
        "LeftCtrl", "LeftShift", "LeftAlt", "LeftSuper", "RightCtrl", "RightShift", "RightAlt", "RightSuper", "Menu",
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H",
        "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
        "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12",
        "Apostrophe", "Comma", "Minus", "Period", "Slash", "Semicolon", "Equal", "LeftBracket",
        "Backslash", "RightBracket", "GraveAccent", "CapsLock", "ScrollLock", "NumLock", "PrintScreen",
        "Pause", "Keypad0", "Keypad1", "Keypad2", "Keypad3", "Keypad4", "Keypad5", "Keypad6",
        "Keypad7", "Keypad8", "Keypad9", "KeypadDecimal", "KeypadDivide", "KeypadMultiply",
        "KeypadSubtract", "KeypadAdd", "KeypadEnter", "KeypadEqual",
    };
    
    //Modifier keys to press along with shotcut key - Or multiple keys together as needed
    public readonly ImGuiModFlags Modifiers;
            
    //Key to press in combination with the modifiers to trigger this shortcut
    public readonly ImGuiKey Key;

    public ImGuiShortcut(ImGuiKey key, ImGuiModFlags modifiers = ImGuiModFlags.None)
    {
        if(key < ImGuiKey.NamedKey_BEGIN || key > ImGuiKey.KeypadEqual)
        {
            throw new ArgumentException($"{key} is not a valid value for a shortcut key");
        }
        
        Modifiers = modifiers;
        Key = key;
    }
    
    public bool IsShortcutPressed()
    {
        if(ImGui.IsKeyPressed(Key) == false)
        {
            return false;
        }
        
        var io = ImGui.GetIO();
        
        if((Modifiers & ImGuiModFlags.Ctrl) != 0)
        {
           if(io.KeyCtrl == false)
           {
               return false;
           }
        }
        
        if((Modifiers & ImGuiModFlags.Shift) != 0)
        {
            if(io.KeyShift == false)
            {
                return false;
            }
        }

        if((Modifiers & ImGuiModFlags.Alt) != 0)
        {
            if(io.KeyAlt == false)
            {
                return false;
            }
        }
        
        if((Modifiers & ImGuiModFlags.Super) != 0)
        {
            if(io.KeySuper == false)
            {
                return false;
            }
        }
        
        return true;
    }
    
    public override string ToString()
    {
        var stringBuilder = new StringBuilder(32);

        if((Modifiers & ImGuiModFlags.Ctrl) != 0)
        {
            stringBuilder.Append("Ctrl+");
        }
        
        if((Modifiers & ImGuiModFlags.Shift) != 0)
        {
            stringBuilder.Append("Shift+");
        }
        
        if((Modifiers & ImGuiModFlags.Alt) != 0)
        {
            stringBuilder.Append("Alt+");
        }
        
        if((Modifiers & ImGuiModFlags.Super) != 0)
        {
            stringBuilder.Append(ImGui.GetIO().ConfigMacOSXBehaviors ? "Cmd+" : "Super+");
        }

        stringBuilder.Append(GKeyNames[(int)Key - (int)ImGuiKey.NamedKey_BEGIN]);
        
        return stringBuilder.ToString();
    }
}