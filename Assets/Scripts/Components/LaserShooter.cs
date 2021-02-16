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

    public IEnumerator coroutine;

    void Start()
    {
        coroutine = ShootLasers();
    }

    public IEnumerator ShootLasers()
    {
        float elapsed = 0;
        while (elapsed < totalTime)
        {
            Fire();
            elapsed += waitTime;
            yield return new WaitForSeconds(waitTime);
        }
    }

    void Fire()
    {
        Instantiate(laserPair, transform.position + new Vector3(0, .5f, 0), Quaternion.identity, LevelLoader.CurrentLevel.transform);
    }

    void Stop()
    {
        StopCoroutine(coroutine);
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