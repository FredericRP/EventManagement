namespace FredericRP.EventManagement
{
  public class TwoTypeGameEvent<T, U> : GameEvent
  {
    public GenericValue<T> firstParameter;
    public GenericValue<U> secondParameter;

    public override void Raise(GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandler.TriggerEvent<T, U>(this, firstParameter.value, secondParameter.value);
      else
        eventHandler.TriggerInstanceEvent<T, U>(this, firstParameter.value, secondParameter.value);
    }

    public void Raise(T parameter, U secondParameter, GameEventHandler eventHandler = null)
    {
      this.firstParameter.value = parameter;
      this.secondParameter.value = secondParameter;
      Raise(eventHandler);
    }
  }
}