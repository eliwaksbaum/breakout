using UnityEngine;
using System.Collections.Generic;

public class SplittedBall : MonoBehaviour
{
    public FloatValue speed;
    public GameEvent win;

    bool takeOver = false;
    Vector3 stageBounds;
    public BallSplitter paddle;

    static List<SplittedBall> alives = new List<SplittedBall>();

    void Start()
    {
        stageBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (takeOver)
        {
            if (alives.Count == 1)
            {
                Relinquish();
            }
            if (transform.position.y < -stageBounds.y - 1)
            {
                alives.Remove(this);
                Debug.Log(alives.Count);
                Destroy(gameObject);
            }
        }
    }

    public void Split()
    {
        GetComponent<BallServer>().enabled = false;
        GetComponent<BallExit>().enabled = false;
        takeOver = true;

        if (!alives.Contains(this))
        {
            alives.Add(this);
        }
        alives.Add(Copy(120));
        alives.Add(Copy(240));
    }

    SplittedBall Copy(float angle)
    {
        GameObject newBall = Instantiate(gameObject);
        Rigidbody2D rigidbody = newBall.GetComponent<Rigidbody2D>();
        SplittedBall newSplit = newBall.GetComponent<SplittedBall>();
        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(GetVelocity(angle));
        newSplit.takeOver = true;
        newSplit.paddle = paddle;

        return newSplit;
    }

    Vector2 GetVelocity(float angle)
    {
        Rigidbody2D original = GetComponent<Rigidbody2D>();
        Vector2 direction = original.velocity;
        Vector2 newD = Quaternion.AngleAxis(angle, Vector3.forward) * direction;
        return newD.normalized * speed.Value;
    }

    void Relinquish()
    {
        GetComponent<BallServer>().enabled = true;
        GetComponent<BallExit>().enabled = true;
        paddle.ball = this;
        takeOver = false;
        alives.Clear();
    }

    void LevelOver()
    {
        if (takeOver)
        {
            if (alives.IndexOf(this) == 0)
            {
                Relinquish();
            }
            else
            {
                Destroy(gameObject);
            }
        } 
    }

    void OnEnable()
    {
        win.Add(LevelOver);
    }

    void OnDisable()
    {
        win.Remove(LevelOver);
    }
}