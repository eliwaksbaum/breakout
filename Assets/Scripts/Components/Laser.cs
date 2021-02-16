using UnityEngine;

public class Laser : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    Vector3 stageBounds;

    void Start()
    {
        stageBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + new Vector2(0, .15f));
        if (rigidbody.position.y > stageBounds.y + 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "Brick")
        {
            Destroy(gameObject);
        }
    }
}