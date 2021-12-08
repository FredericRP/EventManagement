using UnityEngine;
using UnityEngine.Events;

namespace FredericRP.EventManagement
{
  [CreateAssetMenu(menuName = "FredericRP/Game Event")]
  public class GameEvent : ScriptableObject
  {
    public virtual void Raise(GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.TriggerEvent(this);
      else
        eventHandler.TriggerInstanceEvent(this);
    }

    public virtual void Raise<T>(T value, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.TriggerEvent<T>(this, value);
      else
        eventHandler.TriggerInstanceEvent<T>(this, value);
    }
    public virtual void Raise<T, U>(T arg1, U arg2, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.TriggerEvent<T, U>(this, arg1, arg2);
      else
        eventHandler.TriggerInstanceEvent<T, U>(this, arg1, arg2);
    }
    public virtual void Raise<T, U, V>(T arg1, U arg2, V arg3, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.TriggerEvent<T, U, V>(this, arg1, arg2, arg3);
      else
        eventHandler.TriggerInstanceEvent<T, U, V>(this, arg1, arg2, arg3);
    }

    public virtual void Listen(UnityAction action, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.AddEventListener(this, action);
      else
        eventHandler.AddInstanceEventListener(this, action);
    }
    public virtual void Listen<T>(UnityAction<T> action, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.AddEventListener<T>(this, action);
      else
        eventHandler.AddInstanceEventListener<T>(this, action);
    }
    public virtual void Listen<T, U>(UnityAction<T, U> action, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.AddEventListener<T, U>(this, action);
      else
        eventHandler.AddInstanceEventListener<T, U>(this, action);
    }
    public virtual void Listen<T, U, V>(UnityAction<T, U, V> action, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.AddEventListener<T, U, V>(this, action);
      else
        eventHandler.AddInstanceEventListener<T, U, V>(this, action);
    }

    public virtual void Delete(UnityAction action, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.RemoveEventListener(this, action);
      else
        eventHandler.RemoveInstanceEventListener(this, action);
    }
    public virtual void Delete<T>(UnityAction<T> action, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.RemoveEventListener<T>(this, action);
      else
        eventHandler.RemoveInstanceEventListener<T>(this, action);
    }
    public virtual void Delete<T, U>(UnityAction<T, U> action, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.RemoveEventListener<T, U>(this, action);
      else
        eventHandler.RemoveInstanceEventListener<T, U>(this, action);
    }
    public virtual void Delete<T, U, V>(UnityAction<T, U, V> action, GameEventHandler eventHandler = null)
    {
      if (eventHandler == null)
        GameEventHandlerSingleton.RemoveEventListener<T, U, V>(this, action);
      else
        eventHandler.RemoveInstanceEventListener<T, U, V>(this, action);
    }
  }
}