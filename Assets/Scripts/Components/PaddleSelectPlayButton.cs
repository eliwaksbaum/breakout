using UnityEngine;

public class PaddleSelectPlayButton : GameButton
{
    public PaddleDisplayer displayer;
    public AudioClip lockedClip;
    AudioSource lockedAudio;

    void Awake()
    {
        lockedAudio = Sounds.AddAudio(gameObject, lockedClip);
    }

    void OnMouseDown()
    {
        if (displayer.Unlocked)
        {
            Sounds.PlayAudio(beep);
            foreach (Callable action in ButtonActions)
            {
                action.Call();
            }
        }
        else
        {
            lockedAudio.Play();
        }
    }
}