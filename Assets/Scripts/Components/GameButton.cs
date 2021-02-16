using UnityEngine;

public class GameButton : MonoBehaviour
{
    public bool selfDestruct; 
    public Callable[] ButtonActions;

    void OnMouseDown()
    {
        foreach (Callable action in ButtonActions)
        {
            action.Call();
        }
        if (selfDestruct)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}