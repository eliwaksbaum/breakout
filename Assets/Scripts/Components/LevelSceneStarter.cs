using UnityEngine;

public class LevelSceneStarter : MonoBehaviour
{
    public GameEvent serve;
    public IntValue health;
    public IntValue score;
    public PaddleSizes paddleSizes;

    void Start()
    {
        serve.Call();
        health.setValue(3);
        score.setValue(0);
        paddleSizes.currentSize = 2;
        LevelLoader.Load(0);
    }
}