using UnityEditor;
using UnityEngine;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(TwoTypeGameEvent<,>))]
  public class TwoTypeGameEventInspector<T, U> : Editor
  {
    public override void OnInspectorGUI()
    {
      GUILayout.Label("GameEvent: " + serializedObject.targetObject.name);
      SerializedProperty firstParameter = serializedObject.FindProperty("firstParameter");
      EditorGUILayout.PropertyField(firstParameter);
      SerializedProperty secondParameter = serializedObject.FindProperty("secondParameter");
      EditorGUILayout.PropertyField(secondParameter);
      if (GUILayout.Button("RAISE"))
      {
        (serializedObject.targetObject as GameEvent).Raise();
      }
      if (serializedObject.hasModifiedProperties)
        serializedObject.ApplyModifiedProperties();
    }
  }

}