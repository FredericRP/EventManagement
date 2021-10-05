using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FredericRP.EventManagement
{
  [System.Serializable]
  public class GenericValue<T>
  {
    [SerializeField]
    T typedValue;
    [SerializeField]
    GenericReference<T> typedReference;
    public enum ValueType { value = 0, reference = 1};
    public ValueType valueType;

    public T value
    {
      get
      {
        return (valueType == ValueType.reference ? typedReference.value : typedValue);
      }
      set
      {
        if (valueType == ValueType.reference)
          typedReference.value = value;
        else
          typedValue = value;
      }
    }
  }
}