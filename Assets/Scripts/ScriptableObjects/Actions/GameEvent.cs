using UnityEngine;
using System;

[CreateAssetMenu]
public class GameEvent : Callable
{
    protected Action thisEvent;

    public void Add(Action function)
    {
        thisEvent += function;
    }

    public void Remove(Action function)
    {
        thisEvent -= function;
    }

    public override void Call()
    {
        if (thisEvent != null)
        {
            thisEvent();
        }
    }
}