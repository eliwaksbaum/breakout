using UnityEngine;

public class WinListener : MonoBehaviour
{
    public GameEvent win;
    int brickCount;

    // void Start()
    // {
    //     brickCount = GetComponentsInChildren<BrickHit>().Length;
    // }
    
    void CheckWin()
    {
        brickCount = GetComponentsInChildren<BrickHit>().Length - 1;
        //brickCount -= 1;
        if (brickCount == 0)
        {
            win.Call();
        }
    }

    void OnEnable()
    {
        BrickHit.OnDie += CheckWin;
    }

    void OnDisable()
    {
        BrickHit.OnDie -= CheckWin;
    }
}