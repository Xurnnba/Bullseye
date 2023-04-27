using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorPalette", menuName = "Custom/ColorPalette", order = 1)]
public class ColorPalette : ScriptableObject
{
    [SerializeField]
    private List<string> colorNames = new List<string>();

    [SerializeField]
    private List<Color> colors = new List<Color>();

    public Color GetColorByName(string colorName)
    {
        int index = colorNames.IndexOf(colorName);

        if (index >= 0 && index < colors.Count)
        {
            return colors[index];
        }
        else
        {
            Debug.LogError("Color not found in the palette!");
            return Color.white; // Return white as default color if not found
        }
    }
}
