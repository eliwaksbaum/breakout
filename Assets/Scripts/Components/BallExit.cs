using UnityEngine;

public class BallExit : MonoBehaviour
{
    Vector3 stageBounds;
    
    public IntValue health;
    public GameEvent serveCall;
    public GameEvent lose;

    public AudioClip loseLifeClip;
    public AudioClip loseGameClip;

    void Start()
    {
        stageBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y < -stageBounds.y - .5f)
       {
           Sounds.PlayAudio(loseLifeClip);
           health.addValue(-1);
           if (health.Value <= 0)
           {
               Sounds.PlayAudio(loseGameClip);
               lose.Call();
               Destroy(this.gameObject);
               return;
           }
           serveCall.Call();
       } 
    }
}