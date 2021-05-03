using UnityEngine;

public class WinListener : MonoBehaviour
{
    public GameEvent win;
    int brickCount;
    //bool done;

    public AudioClip levelWinClip;
    AudioSource levelWinAudio;

    void Awake()
    {
        levelWinAudio = Sounds.AddAudio(gameObject, levelWinClip);
    }

    void Start()
    {
        brickCount = GetComponentsInChildren<BrickHit>().Length;
    }
    
    void CheckWin()
    {
        brickCount -= 1;
        if (brickCount == 0)// && !done)
        {
            levelWinAudio.Play();
            win.Call();
            //done = true;
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