using UnityEditor;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(FloatStringGameEvent))]
  public class FloatStringGameEventInspector : TwoTypeGameEventInspector<float, string>
  { }
}