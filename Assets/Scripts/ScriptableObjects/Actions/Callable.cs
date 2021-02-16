using UnityEngine;

[System.Serializable]
public abstract class Callable : ScriptableObject
{
    public abstract void Call();
}