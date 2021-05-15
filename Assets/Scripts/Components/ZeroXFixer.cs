using UnityEngine;

public class ZeroXFixer : MonoBehaviour
{
    public float tolerance;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (Mathf.Abs(rb.velocity.x) < tolerance && rb.velocity.y < 0)
            {
                float dir = (rb.velocity.x != 0)? rb.velocity.x/Mathf.Abs(rb.velocity.x) : 1;
                rb.velocity = new Vector2(tolerance * dir, rb.velocity.y);
            }
        }
    }
}