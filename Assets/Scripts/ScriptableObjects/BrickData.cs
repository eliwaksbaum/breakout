using UnityEngine;

[CreateAssetMenu]
public class BrickData : ScriptableObject
{
    public Sprite[] brickSprites = new Sprite[4];
    public AudioClip hit1Clip;
    public AudioClip hit2Clip;
    public AudioClip laserClip;
    public AudioClip dieClip;
}
