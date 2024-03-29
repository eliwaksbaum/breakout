﻿using UnityEngine;
using System;

public class IntValue : ScriptableObject
{
    [SerializeField] private int value;

    public int Value {get{return value;}}

    public void setValue(int set)
    {
        value = set;
    }

    public void addValue(int add)
    {
        value += add;
    }
}
