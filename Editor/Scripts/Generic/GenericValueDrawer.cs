using UnityEditor;
using UnityEngine;

namespace FredericRP.EventManagement
{
  [CustomPropertyDrawer(typeof(GenericValue<>))]
  public class GenericValueDrawer : PropertyDrawer
  {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
      // Using BeginProperty / EndProperty on the parent property means that
      // prefab override logic works on the entire property.
      EditorGUI.BeginProperty(position, label, property);

      // Draw label
      Rect referenceFieldRect = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

      Rect typeRect = referenceFieldRect;
      typeRect.width = 64;
      Rect valueRect = referenceFieldRect;
      valueRect.x += 68;
      valueRect.width -= 68;

      // Enum popup value type
      SerializedProperty valueTypeProperty = property.FindPropertyRelative("valueType");
      EditorGUI.PropertyField(typeRect, valueTypeProperty, new GUIContent(""), false);
      // value type == value -> edit value itself
      if (valueTypeProperty.enumValueIndex == 0)
      {
        SerializedProperty valueProperty = property.FindPropertyRelative("typedValue");
        EditorGUI.PropertyField(valueRect, valueProperty, new GUIContent(""));
      } else
      {
        // value type == reference -> edit reference
        SerializedProperty referenceProperty = property.FindPropertyRelative("typedReference");
        EditorGUI.PropertyField(valueRect, referenceProperty, new GUIContent(""));
      }

      property.serializedObject.ApplyModifiedProperties();
      // */

      EditorGUI.EndProperty();
    }
  }
}
