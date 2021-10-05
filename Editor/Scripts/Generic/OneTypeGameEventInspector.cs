using UnityEditor;
using UnityEngine;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(OneTypeGameEvent<>))]
  public class OneTypeGameEventInspector<T> : Editor
  {
    public override void OnInspectorGUI()
    {
      GUILayout.Label("GameEvent: " + serializedObject.targetObject.name);
      SerializedProperty parameter = serializedObject.FindProperty("parameter");
      EditorGUILayout.PropertyField(parameter);
      if (GUILayout.Button("RAISE"))
      {
        (serializedObject.targetObject as GameEvent).Raise();
      }
      if (serializedObject.hasModifiedProperties)
        serializedObject.ApplyModifiedProperties();
    }
  }

}