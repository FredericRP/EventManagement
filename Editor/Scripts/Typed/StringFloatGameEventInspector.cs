using UnityEditor;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(StringFloatGameEvent))]
  public class StringFloatGameEventInspector : TwoTypeGameEventInspector<string, float>
  { }
}