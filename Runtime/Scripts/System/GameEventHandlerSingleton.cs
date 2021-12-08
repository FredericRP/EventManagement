using FredericRP.GenericSingleton;
using UnityEngine.Events;

namespace FredericRP.EventManagement
{
  public class GameEventHandlerSingleton : Singleton<GameEventHandlerSingleton>
  {
    GameEventHandler eventHandler = new GameEventHandler();
    internal static void AddEventListener(GameEvent gameEvent, UnityAction handler)
    {
      Instance.eventHandler.AddInstanceEventListener(gameEvent, handler);
    }

    internal static void AddEventListener<T>(GameEvent gameEvent, UnityAction<T> handler)
    {
      Instance.eventHandler.AddInstanceEventListener<T>(gameEvent, handler);
    }

    internal static void AddEventListener<T, U>(GameEvent gameEvent, UnityAction<T, U> handler)
    {
      Instance.eventHandler.AddInstanceEventListener<T, U>(gameEvent, handler);
    }

    internal static void AddEventListener<T, U, V>(GameEvent gameEvent, UnityAction<T, U, V> handler)
    {
      Instance.eventHandler.AddInstanceEventListener<T, U, V>(gameEvent, handler);
    }

    internal static void RemoveEventListener(GameEvent gameEvent, UnityAction handler)
    {
      Instance?.eventHandler.RemoveInstanceEventListener(gameEvent, handler);
    }

    internal static void RemoveEventListener<T>(GameEvent gameEvent, UnityAction<T> handler)
    {
      Instance?.eventHandler.RemoveInstanceEventListener<T>(gameEvent, handler);
    }

    internal static void RemoveEventListener<T, U>(GameEvent gameEvent, UnityAction<T, U> handler)
    {
      Instance?.eventHandler.RemoveInstanceEventListener<T, U>(gameEvent, handler);
    }

    internal static void RemoveEventListener<T, U, V>(GameEvent gameEvent, UnityAction<T, U, V> handler)
    {
      Instance?.eventHandler.RemoveInstanceEventListener<T, U, V>(gameEvent, handler);
    }
    internal static bool TriggerEvent(GameEvent gameEvent)
    {
      return Instance.eventHandler.TriggerInstanceEvent(gameEvent);
    }

    internal static bool TriggerEvent<T>(GameEvent gameEvent, T value)
    {
      return Instance.eventHandler.TriggerInstanceEvent<T>(gameEvent, value);
    }

    internal static bool TriggerEvent<T, U>(GameEvent gameEvent, T value, U secondValue)
    {
      return Instance.eventHandler.TriggerInstanceEvent<T, U>(gameEvent, value, secondValue);
    }

    internal static bool TriggerEvent<T, U, V>(GameEvent gameEvent, T value, U secondValue, V thirdValue)
    {
      return Instance.eventHandler.TriggerInstanceEvent<T, U, V>(gameEvent, value, secondValue, thirdValue);
    }

  }
}