using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class LevelLoader
{
    static GameObject currentLevel;
    public static GameObject CurrentLevel {get{return currentLevel;}}
    static int currentIndex;

    //YOOOOO, NUMBER OF LEVELS HERE
    static int maxLevel = 7;

    public static void Load(int index)
    {
        Unload();
        string address = "Levels/" + index.ToString();
        if (index >= maxLevel)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(address);
            handle.Completed += SetCurrent;
        }
        currentIndex = index;
    }

    static void SetCurrent(AsyncOperationHandle<GameObject> handle)
    {
        currentLevel = handle.Result;
    }

    public static void LoadNext()
    {
        Load(currentIndex + 1);
    }

    static void Unload()
    {
        MonoBehaviour.Destroy(currentLevel);
    }
}