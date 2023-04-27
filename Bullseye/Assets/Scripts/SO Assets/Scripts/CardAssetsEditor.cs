using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ColorPalette))]
public class ColorPaletteEditor : Editor
{
    private SerializedProperty colorNames;
    private SerializedProperty colors;
    private int selectedIndex;

    private void OnEnable()
    {
        colorNames = serializedObject.FindProperty("colorNames");
        colors = serializedObject.FindProperty("colors");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Display the dropdown list of color names
        selectedIndex = EditorGUILayout.Popup("Select Color", selectedIndex, colorNames.ToArray());

        // Display and edit the actual color corresponding to the selected name
        EditorGUILayout.PropertyField(colors.GetArrayElementAtIndex(selectedIndex), new GUIContent("Color"));

        serializedObject.ApplyModifiedProperties();
    }
}
