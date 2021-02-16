//This Component can only used in concurrence with a Rigidbody2D

using UnityEngine;

public class StopOnLevelEnd : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    public GameEvent win;
    public GameEvent lose;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Stop()
    {
        rigidbody.velocity = Vector2.zero;
    }

    void OnEnable()
    {
        win.Add(Stop);
        lose.Add(Stop);
    }

    void OnDisable()
    {
        win.Remove(Stop);
        lose.Remove(Stop);
    }
}