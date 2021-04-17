using UnityEngine;

public class GameButton : MonoBehaviour
{
    public bool selfDestruct; 
    public Callable[] ButtonActions;
    public AudioClip beep;

    void OnMouseDown()
    {
        if (beep != null)
        {
            Sounds.PlayAudio(beep);
        }
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