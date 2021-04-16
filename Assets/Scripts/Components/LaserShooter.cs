using UnityEngine;
using System.Collections;

public class LaserShooter : MonoBehaviour
{
    public float totalTime;
    public float waitTime;
    public GameObject laserPair;
    public GameEvent win;
    public GameEvent lose;
    public GameEvent serveCall;

    public IEnumerator fireRoutine;
    bool shooting;

    public AudioClip pewClip;
    AudioSource pewAudio;

    void Awake()
    {
        pewAudio = Sounds.AddAudio(gameObject, pewClip);
    }

    void Start()
    {
        fireRoutine = ShootLasers();
    }

    public IEnumerator ShootLasers()
    {
        float elapsed = 0;
        shooting = true;
        while (elapsed < totalTime)
        {
            Fire();
            elapsed += waitTime;
            yield return new WaitForSeconds(waitTime);
        }
        shooting = false;
    }

    void Fire()
    {
        pewAudio.Play();
        Instantiate(laserPair, transform.position + new Vector3(0, .5f, 0), Quaternion.identity, LevelLoader.CurrentLevel.transform);
    }

    void Stop()
    {
        if (shooting)
        {
            StopCoroutine(fireRoutine);
        }
    }

    void OnEnable()
    {
        serveCall.Add(Stop);
        win.Add(Stop);
        lose.Add(Stop);
    }

    void OnDisable()
    {
        serveCall.Remove(Stop);
        win.Remove(Stop);
        lose.Remove(Stop);
    }
}