using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class CustomMultipleSelectionPopupDrawer : PropertyDrawer
{
    public static void DrawMultipleSelectionPopup(Rect position, SerializedProperty property, GUIContent label,string[] selectionNames)
    {
        EditorGUI.BeginProperty(position, label, property);
        Rect prefixPosition = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        string name;
        int arraySize = property.arraySize;
        if(arraySize == 0)
        {
            name = "None";   
        }
        else if(arraySize == 1) 
        {
            int index = property.GetArrayElementAtIndex(0).intValue;
            name = selectionNames[index];
        }
        else
        {
            name = "Mult";
        }

        GUIStyle buttonStyle = new GUIStyle(EditorStyles.popup);
        buttonStyle.padding.top = 2;
        buttonStyle.padding.bottom = 2;
        float baseHeight = GUI.skin.textField.CalcSize(new GUIContent()).y;
        Rect popRect = new Rect(prefixPosition.x, position.y, position.x + position.width - prefixPosition.x, baseHeight);
        if (GUI.Button(popRect, name, buttonStyle))
        {
            CustomMultipleSelectionPopupWindow window = CustomMultipleSelectionPopupWindow.CreateInstance<CustomMultipleSelectionPopupWindow>();
            var windowRect = prefixPosition;
            window.Init(property, selectionNames);
            windowRect.position = GUIUtility.GUIToScreenPoint(windowRect.position);
            windowRect.height = popRect.height + 1;
            window.ShowAsDropDown(windowRect, new Vector2(windowRect.width, 400));
        }
        EditorGUI.EndProperty();
    }
}