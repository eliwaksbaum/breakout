using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : Callable
{
    public string targetScene;

    public override void Call()
    {
        SceneManager.LoadScene(targetScene);
    }
}