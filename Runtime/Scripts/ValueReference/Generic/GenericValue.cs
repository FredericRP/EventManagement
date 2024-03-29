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
        {
          if (typedReference != null)
            typedReference.value = value;
          else
            Debug.LogError("Setting a value for the reference is not allowed when the reference is not set.");
        }
        else
          typedValue = value;
      }
    }
    /// <summary>
    /// Conversion operator to facilitate usage of this generic value
    /// </summary>
    public static implicit operator T(GenericValue<T> genValue) => genValue.value;
  }
}