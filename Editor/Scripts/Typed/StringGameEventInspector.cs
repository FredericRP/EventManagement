using UnityEditor;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(StringGameEvent))]
  public class StringGameEventInspector : OneTypeGameEventInspector<string>
  {
  }
}