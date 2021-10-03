using UnityEngine;

namespace FredericRP.EventManagement
{
  [CreateAssetMenu(menuName = "FredericRP/Integer Game Event")]
  public class IntGameEvent : GameEvent
  {
    public int parameter;

    public override void Raise(GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandler.TriggerEvent<int>(this, parameter);
      else
        eventHandler.TriggerInstanceEvent<int>(this, parameter);
    }

    public void Raise(int parameter, GameEventHandler eventHandler = null)
    {
      base.Raise<int>(parameter, eventHandler);
    }
  }
}