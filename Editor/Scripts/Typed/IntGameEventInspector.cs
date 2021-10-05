using UnityEditor;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(IntGameEvent))]
  public class IntGameEventInspector : OneTypeGameEventInspector<int>
  {
  }
}