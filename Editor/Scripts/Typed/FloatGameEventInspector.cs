using UnityEditor;

namespace FredericRP.EventManagement
{
  [CustomEditor(typeof(FloatGameEvent))]
  public class FloatGameEventInspector : OneTypeGameEventInspector<float>
  {
  }
}