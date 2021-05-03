using UnityEngine;
using System;
using System.Collections;

public class PowerSpawner : MonoBehaviour
{
    public PowerChance[] powers;
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

    Tuple<float, float>[] thresholds;

    void Start()
    {
        coroutine = RollForSpawn();
        stageBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector3 extents = powers[0].power.GetComponent<SpriteRenderer>().bounds.extents;
        spawnBounds = stageBounds.x - extents.x;
        spawnHeight = stageBounds.y + extents.y;
        thresholds = DivvySpinner();
    }

    IEnumerator RollForSpawn()
    {
        while(rolling)
        {
            if (UnityEngine.Random.value < dropChancePerInterval)
            {
                Spawn();
            }
            yield return new WaitForSeconds(interval);
        }
    }

    Tuple<float, float>[] DivvySpinner()
    {
        Tuple<float, float>[] pairs = new Tuple<float, float>[powers.Length];
        
        float rolling = 0;
        for (int i = 0; i < powers.Length; i++)
        {
            float end = rolling + powers[i].relativeChance;
            pairs[i] = new Tuple<float, float>(rolling, end);
            rolling += powers[i].relativeChance;
            Debug.Log(pairs[i]);
        }
        return pairs;
    }

    int RandomIndex()
    {
        float spin = UnityEngine.Random.value;
        for (int i = 0; i < thresholds.Length; i++)
        {
            if (thresholds[i].Item1 <= spin && spin <= thresholds[i].Item2)
            {
                return i;
            }
        }
        return 0;
    }

    void Spawn()
    {
        int powerIndex = RandomIndex();
        Debug.Log(powerIndex);

        float x = UnityEngine.Random.Range(-spawnBounds, spawnBounds);
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