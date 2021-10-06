using UnityEditor;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(StringIntGameEvent))]
  public class StringIntGameEventInspector : TwoTypeGameEventInspector<string, int>
  {
  }
}