using UnityEditor;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(BoolStringGameEvent))]
  public class BoolStringGameEventInspector : TwoTypeGameEventInspector<bool, string>
  { }
}