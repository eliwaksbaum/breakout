using UnityEngine;
using System.Collections;

public class PowerSpawner : MonoBehaviour
{
    public PowerChance[] powers;
    public System.ValueTuple<float> tuple;
    public float interval;
    public float dropChancePerInterval;
    public GameEvent serveCall;
    public GameEvent win;
    public GameEvent lose;

    bool rolling = false;
    IEnumerator coroutine;
    Vector3 stageBounds;
    float spawnBounds;
    float spawnHeight;

    void Start()
    {
        coroutine = RollForSpawn();
        stageBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector3 extents = powers[0].power.GetComponent<SpriteRenderer>().bounds.extents;
        spawnBounds = stageBounds.x - extents.x;
        spawnHeight = stageBounds.y + extents.y;
    }

    IEnumerator RollForSpawn()
    {
        while(rolling)
        {
            if (Random.value < dropChancePerInterval)
            {
                Spawn();
            }
            yield return new WaitForSeconds(interval);
        }
    }

    void Spawn()
    {
        int powerIndex = Random.Range(0, powers.Length);
        float x = Random.Range(-spawnBounds, spawnBounds);
        Instantiate(powers[powerIndex].power, new Vector3(x, spawnHeight, 0), Quaternion.identity, LevelLoader.CurrentLevel.transform);
    }

    void Update()
    {
        if (Input.GetButtonDown("Release") && !rolling)
        {
            rolling = true;
            StartCoroutine(coroutine);
        }
    }

    void Stop()
    {
        StopCoroutine(coroutine);
        rolling = false;
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