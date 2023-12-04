using UnityEngine;

namespace FredericRP.EventManagement
{
  [CreateAssetMenu(menuName = "FredericRP/Bool-String Game Event")]
  public class BoolStringGameEvent : TwoTypeGameEvent<bool, string>
  { }
}