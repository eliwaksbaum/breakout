using UnityEngine;
using System.Collections;

public class LaserShooter : MonoBehaviour
{
    public float totalTime;
    public float waitTime;
    public GameObject laser;
    public float laserOffset;
    public GameEvent win;
    public GameEvent lose;
    public GameEvent serveCall;

    IEnumerator currentShootRoutine;
    bool shooting;

    public AudioClip pewClip;
    AudioSource pewAudio;

    void Awake()
    {
        pewAudio = Sounds.AddAudio(gameObject, pewClip);
    }

    public void ShootLasers()
    {
        currentShootRoutine = _ShootLasers();
        StartCoroutine(currentShootRoutine);
    }

    public IEnumerator _ShootLasers()
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
        Instantiate(laser, transform.position + new Vector3(laserOffset, .5f, 0), Quaternion.identity);
        Instantiate(laser, transform.position + new Vector3(-laserOffset, .5f, 0), Quaternion.identity);
    }

    void Stop()
    {
        if (shooting)
        {
            StopCoroutine(currentShootRoutine);
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