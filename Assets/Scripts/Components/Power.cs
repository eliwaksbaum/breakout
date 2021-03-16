﻿using UnityEngine;

public class Power : MonoBehaviour
{
    public FloatValue powerSpeed;
    public GameEvent serveCall;

    Vector3 stageBounds;
    Rigidbody2D rb;

    void Start()
    {
        stageBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (transform.position.y < -stageBounds.y - 1)
        {
            Destroy(gameObject);
        }
        rb.MovePosition(rb.position - new Vector2(0, powerSpeed.Value));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Paddle")
        {
            DoPower(collider.gameObject);
            Destroy(gameObject);
        }
    }

    protected virtual void DoPower (GameObject paddle) {}

    void GetOut()
    {
        Destroy(gameObject);
    }

    void OnEnable()
    {
        serveCall.Add(GetOut);
    }

    void OnDisable()
    {
        serveCall.Remove(GetOut);
    }
}