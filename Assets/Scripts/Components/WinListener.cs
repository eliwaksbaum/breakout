using UnityEngine;

public class WinListener : MonoBehaviour
{
    public GameEvent win;
    int brickCount;

    public AudioClip levelWinClip;
    AudioSource levelWinAudio;

    void Awake()
    {
        levelWinAudio = Sounds.AddAudio(gameObject, levelWinClip);
    }
    
    void CheckWin()
    {
        brickCount = GetComponentsInChildren<BrickHit>().Length - 1;
        //brickCount -= 1;
        if (brickCount == 0)
        {
            levelWinAudio.Play();
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