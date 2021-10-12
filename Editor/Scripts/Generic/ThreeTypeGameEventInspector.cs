using UnityEditor;
using UnityEngine;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(ThreeTypeGameEvent<,,>))]
  public class ThreeTypeGameEventInspector<T, U, V> : Editor
  {
    public override void OnInspectorGUI()
    {
      GUILayout.Label("GameEvent: " + serializedObject.targetObject.name);
      SerializedProperty firstParameter = serializedObject.FindProperty("firstParameter");
      EditorGUILayout.PropertyField(firstParameter);
      SerializedProperty secondParameter = serializedObject.FindProperty("secondParameter");
      EditorGUILayout.PropertyField(secondParameter);
      SerializedProperty thirdParameter = serializedObject.FindProperty("thirdParameter");
      EditorGUILayout.PropertyField(thirdParameter);
      if (GUILayout.Button("RAISE"))
      {
        (serializedObject.targetObject as GameEvent).Raise();
      }
      if (serializedObject.hasModifiedProperties)
        serializedObject.ApplyModifiedProperties();
    }
  }

}