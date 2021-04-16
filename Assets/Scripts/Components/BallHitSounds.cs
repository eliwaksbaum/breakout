using UnityEngine;

public class BallHitSounds : MonoBehaviour
{
    public AudioClip hitClip;
    AudioSource hitAudio;

    void Awake()
    {
        hitAudio = Sounds.AddAudio(gameObject, hitClip);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Wall" || tag == "Block")
        {
            hitAudio.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Paddle")
        {
            hitAudio.Play();
        }
    }
}