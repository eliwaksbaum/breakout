using UnityEngine;

public class BadAngleFixer : MonoBehaviour
{
    public FloatValue maxAngle;
    public FloatValue speed;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Rigidbody2D rigidbody= collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 velocity = rigidbody.velocity;
            float angle = Vector2.SignedAngle(Vector2.up, velocity);
            float newAngle = 0;

            if (maxAngle.Value < angle && angle < 180 - maxAngle.Value)
            {
                newAngle = (angle < 90) ? maxAngle.Value : 180 - maxAngle.Value;
            }
            else if (-maxAngle.Value > angle && angle > -180 + maxAngle.Value)
            {
                newAngle = (angle > -90) ? -maxAngle.Value : -180 + maxAngle.Value;
            }

            if (newAngle != 0)
            {
                Vector2 newVelocity = Quaternion.AngleAxis(newAngle, Vector3.forward) * Vector2.up;
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(newVelocity * speed.Value);
            }            
        }
    }
}