using UnityEngine;

[CreateAssetMenu]
public class BrickData : ScriptableObject
{
    public Sprite[] brickSprites = new Sprite[4];
    public int value;
    public AudioClip hit1Clip;
    public AudioClip hit2Clip;
    public AudioClip dieClip;
}
