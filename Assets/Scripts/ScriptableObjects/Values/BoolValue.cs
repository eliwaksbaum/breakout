using UnityEngine;
using System;

public class BoolValue : ScriptableObject
{
    [SerializeField] private bool value;

    public bool Value {get{return value;}}

    public void SetValue(bool set)
    {
        value = set;
    }
}