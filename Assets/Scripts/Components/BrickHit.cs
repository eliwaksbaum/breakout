using UnityEngine;
using System;

public class BrickHit : MonoBehaviour
{
    public enum BrickColor {Blue, Green, Red, Purple}

    public BrickColor brickColor;
    public BrickData brickData;
    public IntValue score;

    int health;
    new SpriteRenderer renderer;

    public static event Action OnDie;

    void Start()
    {
        health = (int)brickColor + 1;
        renderer = GetComponent<SpriteRenderer>();
        SetSprite();
    }

    void SetSprite()
    {
        renderer.sprite = brickData.brickSprites[(int)brickColor];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Hit();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Laser")
        {
            Hit();
        }
    }

    void Hit()
    {
        health -= 1;
        score.addValue(10);
        if (health <= 0)
        {
            Die();
            return;
        }
        brickColor -= 1;
        SetSprite();
    }

    void Die()
    {
        OnDie();
        Destroy(gameObject);
    }
}
