using UnityEngine;
using System;
using System.Collections;

public class BrickHit : MonoBehaviour
{
    public enum BrickColor {Blue, Green, Red, Purple}

    public BrickColor brickColor;
    public BrickData brickData;
    public IntValue score;

    int health;
    bool died;
    new SpriteRenderer renderer;

    public static event Action OnDie;

    void Start()
    {
        health = (int)brickColor + 1;
        renderer = GetComponent<SpriteRenderer>();
        SetSprite();
    }

    void Update()
    {
        if (died)
        {
            Die();
        }
    }

    void SetSprite()
    {
        renderer.sprite = brickData.brickSprites[(int)brickColor];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (UnityEngine.Random.value >= 0.5)
            {
                Sounds.PlayAudio(brickData.hit1Clip);
            }
            else
            {
                Sounds.PlayAudio(brickData.hit2Clip);
            }
            Hit();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Laser")
        {
            Sounds.PlayAudio(brickData.laserClip);
            Hit();
        }
    }

    void Hit()
    {
        health -= 1;
        score.addValue(brickData.value);
        if (health <= 0)
        {
            died = true;
            return;
        }
        brickColor -= 1;
        SetSprite();
    }

    void Die()
    {
        Sounds.PlayAudio(brickData.dieClip);
        if (OnDie != null)
        {
            OnDie();
        }
        Destroy(gameObject);
    }
}
