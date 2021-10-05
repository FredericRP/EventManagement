using FredericRP.EventManagement;
using UnityEngine;
using UnityEngine.Events;

public class CallUnityActionOnEvent : MonoBehaviour
{
  [SerializeField]
  GameEvent gameEvent = null;
  [SerializeField]
  UnityEvent unityEvent = null;

  private void OnEnable()
  {
    gameEvent?.Listen(unityEvent.Invoke);
  }

  private void OnDisable()
  {
    gameEvent?.Delete(unityEvent.Invoke);
  }
}
