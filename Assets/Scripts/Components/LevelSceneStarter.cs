using UnityEngine;

public class LevelSceneStarter : MonoBehaviour
{
    public GameEvent serve;
    public LevelLoader Load0;
    public IntValue health;
    public IntValue score;
    public PaddleSizes paddleSizes;

    void Start()
    {
        serve.Call();
        Load0.Call();
        health.setValue(3);
        score.setValue(0);
        paddleSizes.currentSize = 2;
    }
}