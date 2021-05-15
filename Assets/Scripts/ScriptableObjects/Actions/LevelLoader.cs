using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Callable
{
    static GameObject currentLevel;
    public static GameObject CurrentLevel {get{return currentLevel;}}
    static int currentIndex;
    
    public GameObject[] levels;
    public GameEvent serve;
    public GameEvent lose;

    void OnEnable()
    {
        lose.Add(Reset);
    }

    void OnDisable()
    {
        lose.Remove(Reset);
    }

    public override void Call()
    {
        if(currentIndex < levels.Length)
        {
            currentLevel = Load(currentIndex);
            currentIndex += 1;
            serve.Call();
        }
        else
        {
            SceneManager.LoadScene("Win");
        }
    }

    GameObject Load(int lvlindex)
    {
        Destroy(currentLevel);
        return Instantiate(levels[lvlindex]);
    }

    void Reset()
    {
        currentIndex = 0;
    }   
}