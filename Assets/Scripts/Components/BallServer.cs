using UnityEngine;

public class BallServer : MonoBehaviour
{
    bool isServing;

    public GameEvent serveCall;
    public FloatValue launchForce;
    public FloatValue maxAngle;
    public Transform spawn;

    new Rigidbody2D rigidbody;
    new Collider2D collider;

    public GameObject aim;
    float aimZAngle;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        //aim = transform.GetChild(0).gameObject;
        //SetServe();
    }

    void Update()
    {
        if (isServing)
        {
            float moveAngle = Input.GetAxis("Horizontal");
            aimZAngle = MoveAim(moveAngle);
            Vector2 launchAngle = Quaternion.AngleAxis(aimZAngle, Vector3.forward) * Vector2.up;
            if (Input.GetButtonDown("Release"))
            {
                Fire(launchAngle);
            }
            
        }
    }

    void Fire(Vector2 launchAngle)
    {
        rigidbody.simulated = true;
        isServing = false;
        aim.SetActive(false);
        rigidbody.AddForce(launchAngle * launchForce.Value);
    }

    public void SetServe()
    {
        isServing = true;
        aim.SetActive(true);
        aimZAngle = 0;
        rigidbody.simulated = false;
        rigidbody.velocity = Vector2.zero;
        transform.position = spawn.position + new Vector3(0, .5f, 0);
    }

    float MoveAim(float input)
    {
        float rotate = Mathf.Clamp((aimZAngle - input * 1.25f), -maxAngle.Value, maxAngle.Value);
        aim.transform.localEulerAngles = new Vector3(0, 0, rotate);
        return rotate; 
    }

    void OnEnable()
    {
        serveCall.Add(SetServe);
    }

    void OnDisable()
    {
        serveCall.Remove(SetServe);
    }
}