using UnityEngine;

public class BounceBallOffPaddle : MonoBehaviour
{
    public FloatValue maxAngle;
    public FloatValue bounceForce;

    new SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            Rigidbody2D ballRigidbody = other.GetComponent<Rigidbody2D>();
            float ballX = other.transform.position.x;
            ballRigidbody.velocity = Vector2.zero;
            PaddleBounce(ballX, ballRigidbody);
        }
    }

    void PaddleBounce(float ballX, Rigidbody2D ballRigidbody)
    {
        float halfWidth = renderer.size.x/2;
        float ratio = (ballX - transform.position.x)/halfWidth;
        float zAngle = ratio * -maxAngle.Value;
        Vector2 bounceAngle = Quaternion.AngleAxis(zAngle, Vector3.forward) * Vector2.up;
        ballRigidbody.AddForce(bounceAngle * bounceForce.Value);
    }
}
