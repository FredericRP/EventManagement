namespace FredericRP.EventManagement
{
  public class OneTypeGameEvent<T> : GameEvent
  {
    public GenericValue<T> parameter;

    public override void Raise(GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandler.TriggerEvent<T>(this, parameter.value);
      else
        eventHandler.TriggerInstanceEvent<T>(this, parameter.value);
    }

    public void Raise(T parameter, GameEventHandler eventHandler = null)
    {
      this.parameter.value = parameter;
      Raise(eventHandler);
    }
  }
}