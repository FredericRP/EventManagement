using UnityEngine.Events;

namespace FredericRP.EventManagement
{
  public class ThreeTypeGameEvent<T, U, V> : GameEvent
  {
    public GenericValue<T> firstParameter;
    public GenericValue<U> secondParameter;
    public GenericValue<V> thirdParameter;

    public override void Raise(GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandler.TriggerEvent<T, U, V>(this, firstParameter.value, secondParameter.value, thirdParameter.value);
      else
        eventHandler.TriggerInstanceEvent<T, U, V>(this, firstParameter.value, secondParameter.value, thirdParameter.value);
    }

    public void Raise(T parameter, U secondParameter, V thirdParameter, GameEventHandler eventHandler = null)
    {
      this.firstParameter.value = parameter;
      this.secondParameter.value = secondParameter;
      this.thirdParameter.value = thirdParameter;
      Raise(eventHandler);
    }

    public void Listen(UnityAction<T, U, V> action, GameEventHandler eventHandler = null)
    {
      base.Listen<T, U, V>(action, eventHandler);
    }
    public void Delete(UnityAction<T, U, V> action, GameEventHandler eventHandler = null)
    {
      base.Delete<T, U, V>(action, eventHandler);
    }
  }
}