using UnityEngine;

public class PaddleSelectButton : MonoBehaviour
{
    public PaddleDisplayer displayer;
    public int handedness;
    
    AudioSource beep;

    void Start()
    {
        beep = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        beep.Play();
        displayer.DisplayNext(handedness);

    }
}