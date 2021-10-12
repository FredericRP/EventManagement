using UnityEditor;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(FloatIntGameEvent))]
  public class FloatIntGameEventInspector : TwoTypeGameEventInspector<float, int>
  { }
}