using UnityEngine;
using System;

public class Paddle : MonoBehaviour
{
    float move;
    new Collider2D collider;
    Vector3 stageBounds;
    
    bool movable;
    bool serving;

    public SpriteValue paddleSprite;
    public GameEvent win;
    public GameEvent loss;
    public GameEvent serveCall;
    public FloatValue speed;
    public Transform spawn;
    [NonSerialized] public float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = paddleSprite.Value;
        renderer.size = new Vector2(2.3f, renderer.size.y); //2.3 is the middle value in Paddle Sizes!
        collider = GetComponent<Collider2D>();
        halfWidth = collider.bounds.extents.x;
        stageBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //SetServe();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        if (serving)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movable = true;
                serving = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (movable)
        {
            Move();
        }
    }

    void Move()
    {
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;

        float clampedX = Mathf.Clamp(x + move * speed.Value, -stageBounds.x + halfWidth, stageBounds.x - halfWidth);
        gameObject.transform.position = new Vector3(clampedX, y, 0);
    }

    public void SetServe()
    {
        serving = true;
        transform.position = spawn.position;
        movable = false;
    }

    public void Stop()
    {
        movable = false;
    }

    void OnEnable()
    {
        serveCall.Add(SetServe);
        win.Add(Stop);
        loss.Add(Stop);
    }

    void OnDisable()
    {
        serveCall.Remove(SetServe);
        win.Remove(Stop);
        loss.Remove(Stop);
    }
}
