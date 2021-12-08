using UnityEngine.Events;

namespace FredericRP.EventManagement
{
  public class OneTypeGameEvent<T> : GameEvent
  {
    public GenericValue<T> parameter;

    public override void Raise(GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.TriggerEvent<T>(this, parameter.value);
      else
        eventHandler.TriggerInstanceEvent<T>(this, parameter.value);
    }

    public void Raise(T parameter, GameEventHandler eventHandler = null)
    {
      this.parameter.value = parameter;
      Raise(eventHandler);
    }

    public void Listen(UnityAction<T> action, GameEventHandler eventHandler = null)
    {
      base.Listen<T>(action, eventHandler);
    }
    public void Delete(UnityAction<T> action, GameEventHandler eventHandler = null)
    {
      base.Delete<T>(action, eventHandler);
    }
  }
}