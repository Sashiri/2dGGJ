using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Observer<T>
{
    public delegate void VoidCall(T value);
    private T value;
    public T Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            Inform();
        }
    }
    public event VoidCall subscribers;
    public Observer(ref T obj)
    {
        value = obj;
    }
    public Observer(T obj)
    {
        value = obj;
    }
    public Observer() { }
    public void Inform()
    {
        subscribers?.Invoke(value);
    }
}
