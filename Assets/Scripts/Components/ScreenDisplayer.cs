using UnityEngine;

public class ScreenDisplayer : MonoBehaviour
{
    public GameEvent loss;
    public GameEvent win;
    public GameObject loseScreen;
    public GameObject winScreen;

    void Lose()
    {
        Instantiate(loseScreen);

    }

    void Win()
    {
        Instantiate(winScreen);
    }

    void OnEnable()
    {
        loss.Add(Lose);
        win.Add(Win);
    }

    void OnDisable()
    {
        loss.Remove(Lose);
        win.Remove(Lose);
    }
}