using UnityEditor;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(StringStringStringGameEvent))]
  public class StringStringStringGameEventInspector : ThreeTypeGameEventInspector<string, string, string>
  { }
}